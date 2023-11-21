using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    public class ProductsCategories : MasterEntity
    {
        [Key]
        public int ID_ProductsCategoris { set; get; }
        public Products Product { get; set; }
        public Categories Category { get; set; }    
    }
}
