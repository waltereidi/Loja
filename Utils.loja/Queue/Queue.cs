using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.loja.Queue
{
    public class Queue : IQueue
    {
        public int counter { get; set; } = 0;
        public List<Task<string>> StoredResults { get; set; } = new List<Task<string>>();
        public string ShowMessage()
        {
            Task.Run(()=>{
                StoredResults.Add(Test());
                    });
            return counter.ToString();
        }
        private async Task<string> Test()
        {
            await Test2();
            Console.WriteLine($"{counter} countersdsd.");
            return $"sdsd{counter}";
        }
        private async Task<string> Test2()
        {
            Thread.Sleep(20000);
            Console.WriteLine($"{counter} countersdsd.");
            return $"sdsd{counter}";
        }
    }

    public interface IQueue
    {
        string ShowMessage();
        List<Task<string>> StoredResults { get; set; }
        int counter { get; set; }
    }
}
