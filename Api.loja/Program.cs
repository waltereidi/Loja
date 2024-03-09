
using NLog.Web;
using System.Security.Authentication;

namespace Api.loja
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
               Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder
                .UseUrls("http://0.0.0.0:5556")
                .UseStartup<Startup>();
            });
    }

}
