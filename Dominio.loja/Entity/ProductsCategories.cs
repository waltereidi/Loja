using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    public class ProductsCategories : MasterEntity
    {
        public Products Product { get; set; }
        public Categories Category { get; set; }    
    }
}
