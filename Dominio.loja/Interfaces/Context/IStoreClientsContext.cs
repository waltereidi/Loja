using Dominio.loja.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Interfaces.Context
{
    public interface IStoreClientsContext
    {
        Clients GetEditMyProfile(string email);

        Clients PutEditMyProfile(Clients clients);
        object GetOrdersRequest();
        
        object PutOrdersRequest();
        object PutCartProducts();
        List<ClientsProductsCart> GetCartProducts(Clients client);
        bool DeleteCartProducts(ClientsProductsCart entity);
    }
}
