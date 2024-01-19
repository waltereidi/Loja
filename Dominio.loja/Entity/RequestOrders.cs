using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    public class RequestOrders : Entity
    {
        [Key]
        public int RequestOrdersId { get; set; }
        [StringLength(2048)]
        public string Description { get; set; }
        public int ClientsId { get; set; }
        public virtual ICollection<RequestOrdersProducts> RequestOrdersProducts { get; set; }
    }
}
