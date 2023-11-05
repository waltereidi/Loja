using Dominio.loja.Entity;
using Dominio.loja.Interfaces;
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
        public virtual DbSet<Category> Category { get; set; }

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
