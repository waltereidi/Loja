
namespace Api.ServicesManager.MicroService.WFileManager
{
    public class WFileManagerMS : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var i = 1;
            return Task.CompletedTask;
        }
    }
}
