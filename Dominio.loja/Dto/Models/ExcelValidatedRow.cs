using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Dto.Models
{
    public class ExcelValidatedRow
    {
        List<ExcelValidatedCell> excelValidatedList { get; set; }
        public bool isValid { get { return excelValidatedList.Where(x => x.isValid == false).Count() == 0; } }
     
        public ExcelValidatedRow(List<ExcelValidatedCell> list )
        {
            excelValidatedList = list; 
        }
    }
}
