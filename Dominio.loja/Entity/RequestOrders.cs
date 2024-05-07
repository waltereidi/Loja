using Framework.loja;
using System.ComponentModel.DataAnnotations;

namespace Dominio.loja.Entity
{
    public class RequestOrders : Entity<int?>
    {

        [StringLength(2048)]
        public string Description { get; set; }
        public int ClientsId { get; set; }
        public virtual ICollection<RequestOrdersProducts> RequestOrdersProducts { get; set; }
        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}
