using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Interfaces
{
    public interface IStoreProductRepository 
    {
        Task<object>GetCategorias();

        Task<object> GetProdutosCategorias();



    }
}
