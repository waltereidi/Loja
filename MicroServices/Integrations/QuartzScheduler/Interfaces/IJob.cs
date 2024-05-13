using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzScheduler.Interfaces
{
    public interface IJob
    {
        Task Execute(IJobExecutionContext context);
    }
}
