using Api.loja.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Utils.loja.Queue;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;
using Api.loja.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using static Org.BouncyCastle.Math.EC.ECCurve;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.JsonWebTokens;
using Org.BouncyCastle.Asn1.Cmp;
using Api.loja.Contracts;
using static Api.loja.Middleware.AuthenticationMiddleware;
using Api.loja.Middleware;
using Microsoft.AspNetCore.Authorization;

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

        service.AddAuthentication()
            .AddJwtBearer( options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration.GetSection("Jwt:Issuer").Get<string>(),
                    ValidAudience = Configuration.GetSection("Jwt:Key").Get<string>(),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("Jwt:Key").Get<string>())),
                    
                };
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        if (context.HttpContext.Request.Cookies.Any(x => x.Key == "Authentication"))
                            context.Token = context.HttpContext.Request.Cookies["Authentication"];
                        return Task.CompletedTask;
                    }
                };

            });

        //.AddGoogle(googleOptions =>
        //{
        //     googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
        //     googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
        // })
        // .AddFacebook(facebookOptions =>
        // {
        //     facebookOptions.AppId= Configuration["Authentication:Facebook:ClientId"];
        //     facebookOptions.AppSecret = Configuration["Authentication:Facebook:ClientSecret"];
        // });

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
        service.AddRateLimiter(_ => _
            .AddFixedWindowLimiter(policyName: "fixed", options =>
            {
                options.PermitLimit = 2;
                options.Window = TimeSpan.FromSeconds(1);
                options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                options.QueueLimit = 1;
            }));

        service.AddSingleton<StoreContext>();
        service.AddScoped<AuthenticationApplicationService>();
        service.AddScoped<ProductManagerApplicationService>();
        service.AddScoped<PraedicamentaApplicationService>();
        service.AddScoped<UploadApplicationService>();

        //service.AddSingleton<IFileUploadClient , FileUploadClient>();
        //service.AddSingleton<FileUploadServer>();

        //Importante para não quebrar o com o modelBuilder do EFCore
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
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Loja Api");
            c.DocumentTitle = "Loja BackEnd";
        });
        //app.UseMiddleware<AuthenticationMiddleware>();
        app.UseRateLimiter();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        app.UseCors(option=>option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(origin => new Uri(origin).Host =="localhost"));
    }
}
   
