using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quartz;
using QuartzScheduler.Interfaces;
using QuartzScheduler.Jobs;

namespace Tests.loja.IntegrationsTest.QuartzScheduler
{
    [TestClass]
    public class QuartzSchedulerTest
    {
        private readonly IQuartzScheduler _scheduler;
        private readonly CronExpression _cron;
        /// <summary>
        /// Constructor handles needed steps for quartz initialization <br></br>
        /// Open console debug for watch ticks from cron<br></br>
        /// <seealso href="https://www.quartz-scheduler.org/documentation/quartz-2.3.0/tutorials/crontrigger.html">Cron generator</seealso>
        /// </summary>

        public QuartzSchedulerTest()
        {
            _scheduler = new MicroServices.Integrations.QuartzScheduler.QuartzScheduler();
            _scheduler.Start();
            
        }

        [TestMethod]
        public  void CreateNewJob()
        {
            var jobs = _scheduler._scheduler.GetJobGroupNames().Result ;
            Thread.Sleep(20000);
            Assert.IsTrue(jobs.Count()>0);
        }
        

    }

}
