
using MicroServices.Integrations.QuartzScheduler;

namespace Api.ServicesManager.MicroService.QuartzMS
{
    public sealed class QuartzMS : BackgroundService
    {
        private readonly QuartzScheduler service; 
        public QuartzMS()
        {
            service = new QuartzScheduler();
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return service.Start();
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken) 
        {
            return service.Stop();
        }
        
    }
}
