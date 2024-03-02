
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
                       webBuilder.ConfigureKestrel(serverOptions =>
                       {
                           serverOptions.ConfigureHttpsDefaults(co =>
                           {
                               co.SslProtocols = SslProtocols.Tls12;
                           });
                       }).UseStartup<Startup>();
      
                   });
    }

}
