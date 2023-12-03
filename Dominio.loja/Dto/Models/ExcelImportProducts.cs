using Dominio.loja.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.loja.Attributes;

namespace Dominio.loja.Dto.Models
{
    public class ExcelImportProducts
    {
        [ExcelValidationAttributes(ExcelValidation.IsNumber , null)]
        public string ID_Products { get; set; }

        
        [ExcelValidationAttributes(ExcelValidation.StringLength, 1, 60 )]
        public string Name { get; set; }


        [ExcelValidationAttributes(ExcelValidation.Required)]
        [ExcelValidationAttributes(ExcelValidation.StringLength, 1 , 60)]
        public string Description { get; set; }



    }
}
