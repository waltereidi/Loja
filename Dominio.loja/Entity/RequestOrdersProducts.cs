using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    [Table("RequestOrders_Products")]
    public class RequestOrdersProducts : MasterEntity
    {
        [Key]
        public int ID_RequestOrders_Products { get; set; }
        [ForeignKey("ID_RequestOrders")]
        public int ID_RequestOrders { get; set; }
        [ForeignKey("ID_ClientsProducts_Cart")]
        public int ID_Products { get; set; }
        public int Quantity { get; set; }
        [NotMapped]
        public Products Product { get; set; }
        [NotMapped]
        public RequestOrders RequestOrders { get; set; }
    }
}
