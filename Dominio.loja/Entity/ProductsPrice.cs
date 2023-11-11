using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    public class ProductsPrices : MasterEntity
    {
        List<Prices> Price { get; set; }
        Products Products { get; set; }

    }
}
