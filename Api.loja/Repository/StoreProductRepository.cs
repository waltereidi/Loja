using Api.loja;
using Dominio.loja.Entity;
using Dominio.loja.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Repository
{
    public class StoreProductRepository : ApplicationDbContext
    {
       
        public StoreProductRepository() 
        {
        
        }

        public List<Category> GetCategory()
        {
            return Category.ToList();
        }

        public Task<object> GetProductCategory()
        {
            throw new NotImplementedException();
        }
    }

}
