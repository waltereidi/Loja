using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Loja.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.All )]
    public class TestClassAttribute : Attribute 
    {
        public string value { get; set; }

        public DateTime LastModified { get; set; }
        public TestClassAttribute(string field)
        {
            value = value;
            LastModified = DateTime.Now;
        }
    }
}
