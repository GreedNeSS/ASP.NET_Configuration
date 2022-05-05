using IOptionsInterface.Models;
using IOptionsInterface.Middlewares;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("Config.json");
builder.Services.Configure<Person>(builder.Configuration);
builder.Services.Configure<Company>(builder.Configuration.GetSection("company"));
var app = builder.Build();

app.UseMiddleware<PersonMiddleware>();

app.MapGet("/person", (IOptions<Person> options) =>
{
    Person person = options.Value;
    return person;
});
app.MapGet("/company", (IOptions<Company> options) =>
{
    Company company = options.Value;
    return company;
});
app.MapGet("/change/age", (IOptions<Person> options, HttpContext context) =>
{
    try
    {
        options.Value.Age = int.Parse(context.Request.Query["age"]);
        Person person = options.Value;
        return person;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return null;
    }
});

app.Run();
