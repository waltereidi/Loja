
namespace Api.ServicesManager.MicroService.WFileManager
{
    public class WFileManagerMS : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
    }
}
