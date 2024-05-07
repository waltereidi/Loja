using Framework.loja;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.loja.Entity
{
    [Table("RequestOrdersProducts")]
    public class RequestOrdersProducts : Entity<int?>
    {

        [ForeignKey("RequestOrdersId")]
        public int RequestOrdersId { get; set; }
        [ForeignKey("ProductsId")]
        public int ProductsId { get; set; }
        public int Quantity { get; set; }
        public virtual Products Products { get; set; }
        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}
