namespace CreatingConfigurationProvider.ConfigurationProviders
{
    public class TextConfigurationSource : IConfigurationSource
    {
        public string FilePath { get; }

        public TextConfigurationSource(string filename)
        {
            FilePath = filename;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            string filePath = builder.GetFileProvider().GetFileInfo(FilePath).PhysicalPath;
            return new TextConfigurationProvider(filePath);
        }
    }
}
