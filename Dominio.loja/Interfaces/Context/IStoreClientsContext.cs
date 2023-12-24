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
        IQueryable<Clients> GetEditMyProfile();
        IQueryable<RequestOrdersClientsProductsCart> GetOrdersRequest();
        IQueryable<ClientsProductsCart> GetCartProducts();

        bool PutEditMyProfile(Clients clients);
        bool PutOrdersRequest(RequestOrders request);
        bool PutCartProducts(int ID_Products, int ID_Clients , int quantity);
        bool DeleteCartProducts(int ID_ClientsProductsCart);
        bool ChangeAmountCartProduct(int ID_ClientsProductsCart, int quantity);

    }
}
