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
    [Table("ProductsSubCategories")]
    public class ProductsSubCategories : Entity<int>
    {

        public int ProductsId { get; set; }
        public int SubCategoriesId { get; set; }
        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}
