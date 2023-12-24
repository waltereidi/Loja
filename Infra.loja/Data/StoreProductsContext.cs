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
        private DbSet<Categories> Categories { get; set; }
        private DbSet<Prices> Prices { get; set ; }
        private DbSet<Products> Products { get; set; }

        public IQueryable<Categories> GetCategories()
        {
            return Categories;
        }

        public Task<object> GetProductCategory()
        {
            throw new NotImplementedException();
        }
       
    }

}
