using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Attributes
{
    public enum DateTimeFormatValidation
    {
        mmddyyyy = 0,
        ddmmyyyy = 1,
        mmddyyyyHHMMSS = 2,
        ddmmyyyyHHMMSS = 3
    }
}
