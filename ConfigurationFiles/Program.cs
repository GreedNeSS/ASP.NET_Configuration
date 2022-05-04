var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Configuration.AddIniFile("config.ini");
builder.Configuration.AddJsonFile("config.json");
builder.Configuration.AddXmlFile("config.xml");

app.MapGet("/ini", (IConfiguration appConfig) => $"Host: {appConfig["host"]}; Port: {appConfig["port"]}");
app.MapGet("/json", (IConfiguration appConfig) =>
{
    string name = appConfig["user:profile:name"];
    string email = appConfig["user:profile:email"];
    string company = appConfig["work:title"];
    return $"Name: {name}; Email: {email}; Company: {company}";
});
app.MapGet("/xml", (IConfiguration appConfig) =>
{
    string name = appConfig["person:profile:name"];
    string age = appConfig["person:profile:age"];
    string company = appConfig["company:title"];
    return $"Name: {name}; Age: {age}; Company: {company}";
});

app.Run();
