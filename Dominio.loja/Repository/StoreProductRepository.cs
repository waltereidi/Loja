using Dominio.loja.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Repository
{
    public class StoreProductRepository : BaseRepository , IStoreProductRepository
    {
        public StoreProductRepository(IConnectionFactory connectionFactory) : base(connectionFactory) 
        {
        }

        public Task<object> GetCategorias()
        {
            throw new NotImplementedException();
        }

        public Task<object> GetProdutosCategorias()
        {
            throw new NotImplementedException();
        }
    }

}
