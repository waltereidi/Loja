using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    [Table("RequestOrdersProducts")]
    public class RequestOrdersProducts : MasterEntity
    {
        [Key]
        public int RequestOrdersProductsId { get; set; }
        [ForeignKey("RequestOrdersId")]
        public int RequestOrdersId { get; set; }
        [ForeignKey("ClientsProductsCartId")]
        public int ProductsId { get; set; }
        public int Quantity { get; set; }
        [NotMapped]
        public virtual Products Products { get; set; }
        [NotMapped]
        public virtual RequestOrders RequestOrders { get; set; }
    }
}
