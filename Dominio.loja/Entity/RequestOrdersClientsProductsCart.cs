using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    [Table("RequestOrders_clientsProducts_Cart")]
    public class RequestOrdersClientsProductsCart : MasterEntity
    {
        [Key]
        public int ID_RequestOrders_clientsProducts_Cart { get; set; }
        [ForeignKey("ID_RequestOrders")]
        public int ID_RequestOrders { get; set; }
        [ForeignKey("ID_ClientsProducts_Cart")]
        public int ID_ClientsProducts_Cart { get; set; }
        [NotMapped]
        public ClientsProductsCart ClientsProductCart { get; set; }
        [NotMapped]
        public RequestOrders RequestOrders { get; set; }
    }
}
