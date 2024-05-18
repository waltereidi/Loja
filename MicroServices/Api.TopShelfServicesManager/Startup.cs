using Api.TopShelfServicesManager.Contracts;
using Api.TopShelfServicesManager.MicroService;
using Api.TopShelfServicesManager.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.ServiceProcess;
using System.Text.Json.Serialization;
using System.Threading;
using Topshelf;

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
            service.AddSwaggerGen(options =>
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                }
                ));

            service.AddControllers()
           .AddJsonOptions(options =>
           {
               options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
           });
            //TopShelf
            HostFactory.Run(c =>
            {
                c?.EnablePauseAndContinue();
                c?.EnableShutdown();
                // 👇 Add here microservices integrations to be managed
                c?.Service<TopShelfQuartzScheduler>(sc =>
                {
                    sc.ConstructUsing(() => new TopShelfQuartzScheduler());
                    sc.WhenCustomCommandReceived((s, hostControl, command) =>
                    {
                        switch (command)
                        {
                            case (int)WindowsServiceCommand.QuartzStart: s.Start(null); break;
                            case (int)WindowsServiceCommand.QuartzStop: s.Stop(null); break;
                        }
                    });
                });
                
                c?.OnException(ex => Console.WriteLine(ex.Message));
                c?.RunAsNetworkService();
                c?.StartManually();
                c?.SetDescription(string.Intern("TopShelf MicroServices Manager"));
                c?.SetDisplayName(string.Intern(Configuration.GetSection("TopShelfServiceName").Value));
                c?.SetServiceName(string.Intern(Configuration.GetSection("TopShelfServiceName").Value));
                c?.EnableServiceRecovery(r =>
                {
                    r?.OnCrashOnly();
                    r?.RestartService(1); //first
                    r?.RestartService(1); //second
                    r?.RestartService(1); //subsequents
                    r?.SetResetPeriod(0);
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

