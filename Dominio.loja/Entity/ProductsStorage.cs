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
    [Table("productsStorage")]
    public class ProductsStorage : Entity<int?>
    {
        public int Quantity { get; set; }
        [StringLength(255)]
        public string Description { get; set; }

        [ForeignKey("ProductsId")]
        public int ProductsId { get; set; }
        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}
