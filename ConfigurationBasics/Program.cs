var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
{
    { "token", "214365" },
    { "port", "8080" },
});
var app = builder.Build();
app.Configuration["UserName"] = "Greed";
app.Configuration["UserAge"] = "30";

app.MapGet("/", (IConfiguration appConfig) => $"Token: {appConfig["token"]}, Port: {appConfig["port"]}");
app.MapGet("/user", (IConfiguration appConfig) => new {Name = appConfig["UserName"],
    Age = int.Parse(appConfig.GetSection("UserAge").Value)});

app.Run();
