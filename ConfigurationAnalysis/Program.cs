using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("config.json");
var app = builder.Build();

app.MapGet("/", (IConfiguration appConfig) => GetSectionContent(appConfig));

app.Run();

string GetSectionContent(IConfiguration config)
{
    StringBuilder sb = new();

    foreach (var section in config.GetChildren())
    {
        sb.Append($"\"{section.Key}\": ");

        if (section.Value == null)
        {
            string subSectionContent = GetSectionContent(section);
            sb.Append($"{{\n\t{subSectionContent}}},\n");
        }
        else
        {
            sb.Append($"\"{section.Value}\",\n");
        }
    }

    return sb.ToString();
}