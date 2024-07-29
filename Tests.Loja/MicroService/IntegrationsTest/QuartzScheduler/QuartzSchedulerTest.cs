using MicroServices.Integrations.QuartzScheduler;
using MicroServices.Integrations.QuartzScheduler.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quartz;

namespace Tests.loja
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
            _scheduler = new QuartzScheduler();
            _scheduler.Start();

        }

        [TestMethod]
        public void CreateNewJob()
        {
            var jobs = _scheduler._scheduler.GetJobGroupNames().Result;
            Thread.Sleep(20000);
            Assert.IsTrue(jobs.Count() > 0);
        }

        [TestMethod]
        public void GetCurrentRunningJobs()
        {
            Thread.Sleep(20000);
            var jobs = _scheduler._scheduler.GetCurrentlyExecutingJobs().Result;
            Thread.Sleep(20000);
            Assert.IsTrue(jobs.Count() > 0);
        }

    }

}
