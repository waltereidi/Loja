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
            //Tick every second
            _cron = new CronExpression("* * * * * ?");
            _scheduler.SetScheduler();
            _scheduler.Start();
            
        }
        [TestCleanup]
        public void Cleanup()
        {
            _scheduler.ShutDown();
        }

        [TestMethod]
        public void CreateNewJob()
        {
            HelloWorldJob jobInstance = new();
            _scheduler.CreateJob<HelloWorldJob>("testCasejob", "group1", _cron);

            Thread.Sleep(61000);
            Assert.IsTrue(File.Exists(jobInstance.path));

        }

    }

}
