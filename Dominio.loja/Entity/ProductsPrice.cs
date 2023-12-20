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
        public int ID_ProductsPrice { get; set; }
        [ForeignKey("ID_Products")]
        public int ID_Products { get; set; }
        [ForeignKey("ID_Prices")]
        public int ID_Prices { get;set; }
        [NotMapped]
        Prices Price { get; set; }
        [NotMapped]
        Products Product { get; set; }

    }
}
