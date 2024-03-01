using Api.loja.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Api.loja.Middleware;
using Utils.loja.Queue;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using RabbitMQ.loja.Interfaces;
using RabbitMQ.loja;

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
        //.AddGoogle(googleOptions =>
        //{
        //     googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
        //     googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
        // })
        // .AddFacebook(facebookOptions =>
        // {
        //     facebookOptions.AppId= Configuration["Authentication:Facebook:ClientId"];
        //     facebookOptions.AppSecret = Configuration["Authentication:Facebook:ClientSecret"];
        // })
        
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
        service.AddCors(options =>
        {
            options.AddDefaultPolicy(
            policy =>
            {
                policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();            
                
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
        
        service.AddSingleton<IQueue, Queue>();
        service.AddSingleton<StoreContext>();
        service.AddSingleton<AdminContext>();

        //service.AddSingleton<IFileUploadClient , FileUploadClient>();
        //service.AddSingleton<FileUploadServer>();
        service.AddMvc(options =>
        {
            options.EnableEndpointRouting = false;
        });
        service.AddDistributedMemoryCache();
        
        service.AddSession(options =>
        {
            options.Cookie.Name = ".Store.Session";
            options.IdleTimeout = TimeSpan.FromSeconds(10);
            options.Cookie.HttpOnly = false;
            options.Cookie.IsEssential = true;
        });

        CultureInfo[] supportedCultures = new[]
        {
            new CultureInfo("pt-BR"),
        };
        service.Configure<RequestLocalizationOptions>(options =>
        {
            options.DefaultRequestCulture = new RequestCulture("pt-BR");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
            options.RequestCultureProviders = new List<IRequestCultureProvider>
        {
            new QueryStringRequestCultureProvider(),
            new CookieRequestCultureProvider()
        };
        });
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


        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        app.UseSession();
        app.UseMvc();
        app.UseMiddleware<CustomMiddleware>();
        app.UseCors();
    }
}
   
