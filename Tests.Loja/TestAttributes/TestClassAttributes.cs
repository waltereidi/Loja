using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Loja.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple=false)]
    public class TestClassAttribute : Attribute 
    {
        public string value { get; set; }

        public DateTime LastModified { get; set; }
        public TestClassAttribute(string field)
        {
            value = field;
            LastModified = DateTime.Now;
        }
        public bool ValidateLength(int size ,string value )
        {
            
            return value.Length > size;
        }
    }
}
