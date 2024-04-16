using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    [Table("products")]
    public class Products : MasterEntity<int>
    {
        [Key]
        public int ProductsId { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(2048)]
        public string? Description { get; set; }

        public long? Ean { get; set; }
        [StringLength(64)]
        public string? Sku { get; set; }
        public virtual ICollection<ProductsPrices> ProductsPrices { get; set; }
        public virtual ProductsStorage ProductsStorage { get; set; }
        public virtual ProductsCategories ProductsCategories { get; set; }
        public virtual ProductsSubCategories ProductsSubCategories { get; set; }
        public virtual ProductsSubSubCategories ProductsSubSubCategories { get; set; }
      

    }
}
