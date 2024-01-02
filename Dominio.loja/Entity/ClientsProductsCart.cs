using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    [Table("clientsProductsCart")]
    public class ClientsProductsCart : MasterEntity
    {
        [Key]
        public int ClientsProductsCartId {get;set;}
        public int Quantity { get;set;}

        public bool IsActive { get;set;}

        [ForeignKey("ProductsId")]
        public int ProductsId { get; set; }
        [ForeignKey("ClientsId")]
        public int ClientsId { get; set; }

        [NotMapped]
        public Products Products { get; set; }
        [NotMapped]
        public Clients Clients { get; set; }
    }
}
