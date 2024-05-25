using Api.TopShelfServicesManager.Contracts;
using Api.TopShelfServicesManager.MicroService.Quartz;
using Api.TopShelfServicesManager.Services;
using System.Text.Json.Serialization;
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
            service.AddSwaggerGen();

            service.AddControllers()
               .AddJsonOptions(options =>
               {
                   options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
               });
            service.AddScoped<TopShelfApplicationService>();
           
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

