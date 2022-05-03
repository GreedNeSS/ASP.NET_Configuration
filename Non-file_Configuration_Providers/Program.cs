string[] commandLineArgs = { "name=GreedNeSS", "age=30" };

// #1
//var builder = WebApplication.CreateBuilder(args);

// #2
//var builder = WebApplication.CreateBuilder(commandLineArgs);

// #3
var builder = WebApplication.CreateBuilder();
builder.Configuration.AddCommandLine(commandLineArgs);

var app = builder.Build();

app.MapGet("/", (IConfiguration appConfig) => 
    new { 
        Name = appConfig.GetSection("name").Value,
        Age  = appConfig.GetSection("age").Value,
    });

app.Run();
