namespace Api.TopShelfServicesManager
{
    public class Statup(IConfiguration configuration)
    {
        public IConfiguration Configuration { get; set; } = configuration;
        public void ConfigureServices(IServiceCollection service)
        {
        }
    }   
    
}
