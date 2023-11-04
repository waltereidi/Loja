using Dominio.loja.Interfaces;
using Dominio.loja.Repository;
using Microsoft.EntityFrameworkCore;
using Api.loja;

public class Startup
{

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; set; }
    public void ConfigureServices(IServiceCollection service)
    {
        string connectionString = Configuration.GetValue<string>("ConnectionString");
        service.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        service.AddEndpointsApiExplorer();
        service.AddSwaggerGen();
        service.AddAuthorization();

        service.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
        

    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
    }

}
   
