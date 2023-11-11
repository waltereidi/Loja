using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    public class ProductsStorage
    {
        public int Quantity { get; set; }
        
        public string Description { get; set; }

        public Products Product { get; set; } 
    }
}
