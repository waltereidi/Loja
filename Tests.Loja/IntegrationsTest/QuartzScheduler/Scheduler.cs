using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuartzScheduler.Interfaces;

namespace Tests.loja.IntegrationsTest.QuartzScheduler
{
    [TestClass]
    public class Scheduler
    {
        private readonly IQuartzScheduler _scheduler;
        public Scheduler()
        {
            _scheduler = new MicroServices.Integrations.QuartzScheduler.QuartzScheduler();
        }
        

    }

}
