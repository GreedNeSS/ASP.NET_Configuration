using CreatingConfigurationProvider.ConfigurationProviders;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddTextFile("Config.txt");
var app = builder.Build();

app.MapGet("/", (IConfiguration appConfig) => $"Name: {appConfig["name"]};" +
$" Age: {appConfig["age"]}; Company: {appConfig["company"]}");

app.Run();
