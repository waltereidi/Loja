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
        public int ProductsCategoriesId { set; get; }
        [ForeignKey("ProductsId")]
        public int ProductsId { get; set; }
        [ForeignKey("CateogoriesId")]
        public int CateogoriesId { get; set; }
        [NotMapped]
        public Products Products { get; set; }
        [NotMapped]
        public Categories Categories { get; set; }    
    }
}
