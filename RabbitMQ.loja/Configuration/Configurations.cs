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
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile(configFileName, false)
                .Build();
        }
    }
}
