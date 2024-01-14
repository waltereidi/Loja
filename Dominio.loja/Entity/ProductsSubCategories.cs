using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    [Table("ProductsSubCategories")]
    public class ProductsSubCategories
    {
        [Key]
        public int ID_ProductsSubCategories { get; set; }
        public int ID_Products { get; set; }
        public int ID_SubCategories { get; set; }
    }
}
