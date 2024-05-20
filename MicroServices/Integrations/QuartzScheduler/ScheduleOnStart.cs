using MicroServices.Integrations.QuartzScheduler.Jobs;
using Quartz;

namespace MicroServices.Integrations.QuartzScheduler
{
    public record class ScheduledService(CronExpression cron , string jobName , string group , Type t);
    public class ScheduleOnStart
    {
        public List<ScheduledService> ServicesToScheduleOnStart { get; private set; }

        /// <summary>
        /// Constructor handles needed steps for quartz initialization <br></br>
        /// Open console debug for watch ticks from cron<br></br>
        /// <seealso href="https://www.quartz-scheduler.org/documentation/quartz-2.3.0/tutorials/crontrigger.html">Cron generator</seealso>
        /// </summary>
        public ScheduleOnStart()
        {
            ServicesToScheduleOnStart = new List<ScheduledService>();

            //Add here your services
            ServicesToScheduleOnStart.Add(new(new CronExpression("1 * * * * ?") , "HelloWorld" , "Group1" , typeof(HelloWorldJob)));

            //Validation
            EnsureValidState();
        }
        private void EnsureValidState()
        {
            if (ServicesToScheduleOnStart.GroupBy(x => x.jobName).Count() > 1)
                throw new ArgumentException();

        }

    }
}
