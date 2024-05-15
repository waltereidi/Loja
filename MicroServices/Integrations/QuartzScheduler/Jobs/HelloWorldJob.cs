using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace QuartzScheduler.Jobs
{
    public class HelloWorldJob : IJob
    {
        public string path = Path.Combine(Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.Parent.FullName, "Task Scheduler Test.file");
        public async Task Execute(IJobExecutionContext context)
        {
            if(!File.Exists(path))
            {
                File.Create(path);
                Console.WriteLine("CREATED FILE");
                Debug.WriteLine("CREATED FILE");
            }
            Console.WriteLine("FILE ALREADY CREATED");
            Debug.WriteLine("FILE ALREADY CREATED");

        }
    }
}
