using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    public class ProductsPrices : MasterEntity
    {
        [Key]
        public int ID_ProductsPrice { get; set; }

        List<Prices> Price { get; set; }
        Products Products { get; set; }

    }
}
