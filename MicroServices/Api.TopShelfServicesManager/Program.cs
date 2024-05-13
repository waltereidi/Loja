using Microsoft.AspNetCore.RateLimiting;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace Api.TopShelfServicesManager 
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; set; }
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
            app.UseCors(option => option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost"));
        }
    }


}

