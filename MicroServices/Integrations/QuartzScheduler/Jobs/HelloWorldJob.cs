using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzScheduler.Jobs
{
    public class HelloWorldJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            string path =Path.Combine(Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.Parent.FullName, "Task Scheduler Test");
            File.Create(path);
        }
    }
}
