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
    [Table("productsPrices")]
    public class ProductsPrices : Entity<int?>
    {

        [ForeignKey("ProductsId")]
        public int ProductsId { get; set; }
        [ForeignKey("PricesId")]
        public int PricesId { get;set; }
        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}
