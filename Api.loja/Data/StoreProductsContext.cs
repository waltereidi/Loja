using Dominio.loja.Entity;
using Dominio.loja.Interfaces.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.loja.Data
{
    public class StoreProductsContext : DbContext, IStoreProductsContext
    {

        public StoreProductsContext()
        {

        }
        public StoreProductsContext(DbContextOptions<StoreProductsContext> options) : base(options)
        {

        }
        public virtual DbSet<Categories> Category { get; set; }

        public List<Categories> GetCategory()
        {
            return Category.ToList();
        }

        public Task<object> GetProductCategory()
        {
            throw new NotImplementedException();
        }
       
    }

}
