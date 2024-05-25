using MicroServices.Integrations.QuartzScheduler.Interfaces;
using Topshelf;

namespace Api.TopShelfServicesManager.MicroService.Quartz
{

    public class TopShelfQuartzScheduler : ServiceControl
    {
        public IQuartzScheduler _quartz = new MicroServices.Integrations.QuartzScheduler.QuartzScheduler();
        public bool Start(HostControl hostControl)
        {
            try
            {

                _quartz.Start();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool Stop(HostControl hostControl)
        {
            try
            {
                _quartz.Stop();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void ServiceStarted(HostControl hostControl)
        {

        }
    }
}
