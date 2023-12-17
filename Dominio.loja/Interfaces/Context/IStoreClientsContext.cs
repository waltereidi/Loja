using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Interfaces.Context
{
    public interface IStoreClientsContext
    {
        object GetEditMyProfile();

        object PutEditMyProfile();
        object GetOrdersRequest();
        
        object PutOrdersRequest();
        object PutCartProducts();
        object GetCartProducts();
        bool DeleteCartProducts();
    }
}
