using Framework.loja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    public class SubCategoriesProducts : Entity<int?>
    {
        public int ProductsId { get; set; }
        public int SubCategoriesId { get; set; }


        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}
