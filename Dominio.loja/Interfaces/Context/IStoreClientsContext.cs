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

        bool PutEditMyProfile(Clients clients);
        List<RequestOrdersClientsProductsCart> GetOrdersRequest(int ID_Clients);
        
        bool PutOrdersRequest(RequestOrders request);
        bool PutCartProducts(Products product , Clients client);
        List<ClientsProductsCart> GetCartProducts(int ID_Clients);
        bool DeleteCartProducts(ClientsProductsCart entity);
    }
}
