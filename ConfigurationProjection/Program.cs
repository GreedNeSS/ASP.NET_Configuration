using ConfigurationProjection.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
builder.Configuration.AddJsonFile("Config.json");
//builder.Configuration.AddXmlFile("Config.xml");

app.MapGet("/", (IConfiguration config) =>
{
    Person user = config.Get<Person>();
    return user;
});

app.MapGet("/bind", (IConfiguration config) =>
{
    Person user = new();
    config.Bind(user);
    return user;
});

app.Run();
