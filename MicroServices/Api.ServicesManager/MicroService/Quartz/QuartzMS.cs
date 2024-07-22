
namespace Api.ServicesManager.MicroService.QuartzMS
{
    public sealed class QuartzMS : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var i = 1;
            return Task.CompletedTask;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }
        public override Task? ExecuteTask => base.ExecuteTask;

        public override Task StopAsync(CancellationToken cancellationToken) 
        { 
            return base.StopAsync(cancellationToken); 
        }
        
    }
}
