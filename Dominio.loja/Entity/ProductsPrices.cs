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
    public class ProductsPrices : MasterEntity
    {
        [Key]
        public int ProductsPriceId { get; set; }
        [ForeignKey("ProductsId")]
        public int ProductsId { get; set; }
        [ForeignKey("PricesId")]
        public int PricesId { get;set; }
        [NotMapped]
        public virtual Prices Prices { get; set; }
        [NotMapped]
        public virtual Products Products { get; set; }

    }
}
