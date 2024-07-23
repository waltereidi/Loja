using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.loja.Configuration
{
    public class Configurations
    {
        public readonly IConfiguration _configuration;

        public Configurations()
        {
            string configFileName = "appsettings.json";
#if DEBUG
            configFileName = "appsettings.Development.json";
#endif
            var path = Path.Combine(Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.Parent.FullName, "Integrations", "RabbitMQ.loja");
            _configuration = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile(configFileName, false)
                .Build();
        }
    }
}
