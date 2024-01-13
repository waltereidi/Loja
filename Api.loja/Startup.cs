using Microsoft.EntityFrameworkCore;
using Api.loja.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Api.loja.Middleware;
using Utils.loja;
using Utils.loja.Queue;
using Dominio.loja.Interfaces.Context;

public class Startup
{

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; set; }
    public void ConfigureServices(IServiceCollection service)
    {
        var jwtIssuer = Configuration.GetSection("Jwt:Issuer").Get<string>();
        var jwtKey = Configuration.GetSection("Jwt:Key").Get<string>();

        service.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        service.AddEndpointsApiExplorer();

        service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
         .AddJwtBearer(options =>
         {
             options.TokenValidationParameters = new TokenValidationParameters
             {
                 ValidateIssuer = true,
                 ValidateAudience = true,
                 ValidateLifetime = true,
                 ValidateIssuerSigningKey = true,
                 ValidIssuer = jwtIssuer,
                 ValidAudience = jwtIssuer,
                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
             };
         });

        // 👇 Configuring the Authorization Service
        service.AddAuthorization();
        service.AddSwaggerGen();
        service.AddSingleton<IQueue, Queue>();
        service.AddSingleton<IStoreContext ,StoreContext>();
        service.AddSingleton<StoreAdminContext>();
        

        service.AddDistributedMemoryCache();
        service.AddSession( options =>
        {
            options.IdleTimeout = TimeSpan.FromSeconds(10);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;

        });

    }
    public void Configure(IApplicationBuilder app, IHostEnvironment env)
    {
        app.UseHttpsRedirection();
        app.UseRouting();

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
        app.UseMiddleware<CustomMiddleware>();
        
    }
 
}
   
