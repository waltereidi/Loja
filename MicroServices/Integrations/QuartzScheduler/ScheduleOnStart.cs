using Quartz;
using QuartzScheduler.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzScheduler
{
    public record class ScheduledService<T>(CronExpression cron , string jobName) where T:class;
    public class ScheduleOnStart
    {
        


    }
}
