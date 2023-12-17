using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    [Table("productsStore")]
    public class ProductsStorage
    {
        [Key]
        public int ID_ProductsStorage { get; set; }
        public int Quantity { get; set; }
        [StringLength(255)]
        public string Description { get; set; }

        [ForeignKey(nameof(ID_Products))]
        public int ID_Products { get; set; }
        public Products Product { get; set; } 
    }
}
