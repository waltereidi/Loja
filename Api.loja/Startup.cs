﻿using Api.loja.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Utils.loja.Queue;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;
using Api.loja.Service;

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

        service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(120);
                options.SlidingExpiration = true;
                options.AccessDeniedPath = "/Forbidden/";
            })
            .AddJwtBearer(options =>
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

        service.AddSingleton<IQueue, Queue>();
        service.AddSingleton<StoreContext>();
        service.AddScoped<AuthenticationApplicationService>();
        service.AddScoped<ProductManagerApplicationService>();
        service.AddScoped<PraedicamentaApplicationService>();

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

        app.UseRateLimiter();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        app.UseCors(option=>option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(origin => new Uri(origin).Host =="localhost"));
    }
}
   
