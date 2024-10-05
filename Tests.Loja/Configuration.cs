using Microsoft.Extensions.Configuration;

namespace Tests.loja
{
    public class Configuration
    {
        public readonly IConfiguration _configuration;
        public readonly DirectoryInfo _testDirPath;
        
        public Configuration(string project) 
        {
            string configFileName = "appsettings.Development.json";
            var path = Path.Combine(Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.Parent.FullName, project);

            Path.Combine(Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.Parent.FullName, project);
            _configuration = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile(configFileName, false)
                .Build();

            _testDirPath = new(Path.Combine(Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.Parent.FullName, "Tests.loja"));
        }
        public Configuration()
        {
            
            _testDirPath = new(Path.Combine(Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.Parent.FullName, "Tests.loja"));
        }

    }
}
