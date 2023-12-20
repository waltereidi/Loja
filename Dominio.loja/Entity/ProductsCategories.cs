using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    [Table("productsCategories")]
    public class ProductsCategories : MasterEntity
    {
        [Key]
        public int ID_ProductsCategories { set; get; }
        [ForeignKey("ID_Products")]
        public int ID_Products { get; set; }
        [ForeignKey("ID_Cateogories")]
        public int ID_Cateogories { get; set; }
        [NotMapped]
        public Products Product { get; set; }
        [NotMapped]
        public Categories Category { get; set; }    
    }
}
