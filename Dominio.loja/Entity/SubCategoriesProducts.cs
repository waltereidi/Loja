using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    public class SubCategoriesProducts : Entity
    {
        public int SubCategoriesProductsId { get; set; }    
        public int ProductsId { get; set; }
        public int SubCategoriesId { get; set; }    
    }
}
