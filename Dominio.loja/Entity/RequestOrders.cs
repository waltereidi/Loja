using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    public class RequestOrders : MasterEntity<int>
    {

        [StringLength(2048)]
        public string Description { get; set; }
        public int ClientsId { get; set; }
        public virtual ICollection<RequestOrdersProducts> RequestOrdersProducts { get; set; }

        protected override void EnsureValidState()
        {
            throw new NotImplementedException();
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}
