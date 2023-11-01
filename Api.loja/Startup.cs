using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http;
using Infra.loja;
using Dominio.loja.Interfaces;

public class Startup
{
    public IConfiguration Configuration { get; set; }
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration; 
    }
    
    public void ConfigureServices(IServiceCollection service)
    {
        string connectionString = Configuration.GetValue<string>("ConnectionString");
        service.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        service.AddEndpointsApiExplorer();
        service.AddSwaggerGen();
        service.AddAuthorization();

        service.AddSingleton<IConnectionFactory>(provider => new SqlConnectionFactory(connectionString));

    }

}
