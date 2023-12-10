using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Dto.Models
{
    public class ExcelValidatedRow
    {
        public Tuple<bool , string> Validation { get; set; }
        public string Value { get; set; }
        public string? ErrorMessage { get { return Validation.Item1 ? Validation.Item2 : null; } }
        public bool isValid { get { return Validation.Item1; } }
    }
}
