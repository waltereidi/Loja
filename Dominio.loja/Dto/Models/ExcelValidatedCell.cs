using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Dto.Models
{
    public class ExcelValidatedCell
    {
        public Tuple<bool , string> Validation { get; set; }
        public string? Value { get; set; }
        public string? ErrorMessage { get { return Validation.Item1 ? Validation.Item2 : null; } }
        public bool isValid { get { return Validation.Item1; } }
        public ExcelValidatedCell(string value )
        {
            Validation = new Tuple<bool, string>(true, "");
            Value = value;
        }

        public ExcelValidatedCell( string value , Tuple<bool , string > validation )
        {
            Validation = validation;
            Value = value;
        }
        public void AddValidation(Tuple<bool , string > validation )
        {
            Validation = new Tuple<bool , string> (Validation.Item1 == validation.Item1 , String.Concat(Validation.Item2 , validation.Item2) );
        }
    }
}
