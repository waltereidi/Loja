using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.loja.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]
    public class ExcelValidationAttributes : Attribute
    {
        public string Validation { get; set; }
        public string ValidationParameters { get; set; }

        public ExcelValidationAttributes(string validation , string validationParameter )
        {
            Validation = validation;
            ValidationParameters = validationParameter;

        }
        public Tuple<bool , string> StringLength(string value)
        {
            return new Tuple<bool, string>(true, "sdsd");
        }
            

    }
}
