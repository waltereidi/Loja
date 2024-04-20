using Framework.loja;
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
    public class ProductsCategories : Entity<int>
    {

        [ForeignKey("ProductsId")]
        public int ProductsId { get; set; }
        [ForeignKey("CateogoriesId")]
        public int CategoriesId { get; set; }
        public virtual Products Products { get; set; }
        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}
