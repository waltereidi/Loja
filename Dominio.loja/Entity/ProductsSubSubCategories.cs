using Framework.loja;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    [Table("ProductsSubSubCategories")]
    public class ProductsSubSubCategories : Entity<int?>
    {
        public int SubSubCategoriesId { get; set; }
        public int ProductsId { get; set; }
        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}
