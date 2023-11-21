using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    public class ProductsStorage
    {
        [Key]
        public int ID_ProductsStorage { get; set; }
        public int Quantity { get; set; }
        [StringLength(255)]
        public string Description { get; set; }

        public Products Product { get; set; } 
    }
}
