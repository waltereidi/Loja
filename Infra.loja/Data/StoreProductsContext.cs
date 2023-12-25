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
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Prices> Prices { get; set ; }
        public DbSet<Products> Products { get; set; }
        
        public IQueryable<> GetProductCategory()
        {
            throw new NotImplementedException();
        }
       
    }

}
