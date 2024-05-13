using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace QuartzScheduler.Interfaces
{
    public interface IJobExecutionContext
    {
        JsonContent JsonContent { get; set; }

    }
}
