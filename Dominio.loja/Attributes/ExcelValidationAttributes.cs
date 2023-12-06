using Dominio.loja.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Attributes
{
    [AttributeUsage(AttributeTargets.Field  | AttributeTargets.Property, AllowMultiple = true)]
    public class ExcelValidationAttributes : Attribute
    {
        public ExcelValidation Validation { get; set; }
        public string? ValidationParameters { get; set; }
        public int MaxLength { get; set; }
        public int MinLength { get; set; }

        public ExcelValidationAttributes(ExcelValidation validation , string? validationParameter )
        {
            Validation = validation;
            ValidationParameters = validationParameter;
        }
        public ExcelValidationAttributes(ExcelValidation validation, int minLen, int maxLen) 
        {
            if (validation != ExcelValidation.StringLength)
                throw new InvalidOperationException("This constructor can only be used by StringLength");

            if (minLen <= maxLen)
                throw new InvalidDataException("minLen must be smaller or equals than maxLen");
            

            Validation = validation;
            MinLength = minLen;
            MaxLength = maxLen;
        }
        public ExcelValidationAttributes(ExcelValidation validation)
        {
            Validation = validation;
        }

        public Tuple<bool , string> StringLength(string value)
        {
            return new Tuple<bool, string>(true, "sdsd");
        }
            

    }
}
