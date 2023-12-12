using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Enums
{
    public enum ExcelValidation
    {
        StringLength=0,
        DateTimeFormat=1,
        IsNumber=3,
        StringContains=4,
        StringValidationMethod=5,
        Required=6,
        CustomSheetField=7,

    }
}
