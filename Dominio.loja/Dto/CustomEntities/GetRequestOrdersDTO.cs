using Dominio.loja.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Dto.CustomEntities
{
    public class GetRequestOrdersDTO
    {
        public RequestOrders RequestOrder { get; set; }
        public List<ClientsProductsCart> ListClientsProductsCart { get; set; }

        

    }
}
