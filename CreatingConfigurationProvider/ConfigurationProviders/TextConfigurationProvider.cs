using System;
namespace CreatingConfigurationProvider.ConfigurationProviders
{
    public class TextConfigurationProvider : ConfigurationProvider
    {
        public string FilePath { get; set; }
        
        public TextConfigurationProvider(string path)
        {
            FilePath = path;
        }

        public override void Load()
        {
            var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            using (StreamReader streamReader = new StreamReader(FilePath))
            {
                string? line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    line = line.Trim();
                    string[] strs = line.Split("=");
                    data.Add(strs[0], strs[1] ?? "");
                }
            }

            Data = data;
        }
    }
}
