using Dominio.loja.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.loja.Attributes;
namespace Dominio.loja.Dto.Models
{
    public class ExcelImportProducts
    {
        [ExcelValidationAttributes(ExcelValidation.IsNumber , null)]
        public string ID_Products { get; set; }

        
        [ExcelValidationAttributes(ExcelValidation.StringLength, 1 ,2 )]
        public string Name { get; set; }


        [ExcelValidationAttributes(ExcelValidation.Required)]
        [ExcelValidationAttributes(ExcelValidation.StringLength, 1 , 60)]
        [ExcelValidationAttributes(ExcelValidation.CustomSheetField , "Description of product")]
        public string Description { get; set; }

    }
}
