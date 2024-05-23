using Api.TopShelfServicesManager.Contracts;
using Api.TopShelfServicesManager.MicroService;
using Api.TopShelfServicesManager.Services;
using log4net;
using log4net.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.ServiceProcess;
using System.Text.Json.Serialization;
using System.Threading;
using Topshelf;
using Topshelf.HostConfigurators;
using Topshelf.Runtime;

namespace Api.TopShelfServicesManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection service)
        {

            service.AddEndpointsApiExplorer();

            service.AddCors(options =>
            {
                options.AddDefaultPolicy(
                policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
                });
            });

            // 👇 Configuring the Authorization Service
            service.AddAuthorization();
            service.AddSwaggerGen(
                );

            service.AddControllers()
           .AddJsonOptions(options =>
           {
               options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
           });
            service.AddScoped<TopShelfApplicationService>();

            //TopShelf
            HostFactory.Run(c =>
            {
                
                c?.OnException(ex => Console.WriteLine(ex.Message));
                c?.UseAssemblyInfoForServiceInfo();
                
                c?.StartManually();
                c?.RunAsLocalSystem();
                
                // 👇 Add here microservices integrations to be managed
                c?.Service<TopShelfQuartzScheduler>(sc =>
                {
                    
                    sc.ConstructUsing(()=> new TopShelfQuartzScheduler());
                    
                    sc.WhenCustomCommandReceived((s, hostControl, command) =>
                    {
                        switch ((WindowsServiceCommand)command)
                        {
                            case WindowsServiceCommand.QuartzStart: s.Start(hostControl); break;
                            case WindowsServiceCommand.QuartzStop: s.Stop(hostControl); break;
                        }
                    });
                    sc.WhenStarted((tc, hostControl) => tc.Start(hostControl));
                    sc.WhenStopped((tc, hostControl) => tc.Stop(hostControl));
                    
                });
            });
        }
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api TopShelf Services Manager");
                c.DocumentTitle = "Api TopShelfServices Manager";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseCors(option => option
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost"));
        }
    }
}

