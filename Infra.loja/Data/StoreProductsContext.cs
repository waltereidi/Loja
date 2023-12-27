using Dominio.loja.Entity;
using Dominio.loja.Interfaces.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.loja.Data
{
    public class StoreProductsContext : DbContext, IStoreProductsContext
    {

        private readonly string _connectionString;
        public StoreProductsContext(DbContextOptions<StoreProductsContext> options) : base(options)
        {

        }
        public StoreProductsContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        public DbSet<Categories> categories { get; set; } = null!;
        public DbSet<Prices> prices { get; set; } = null!;
        public DbSet<Products> products { get; set; } = null!;
        public DbSet<CategoryPromotion> categoryPromotion { get; set; } = null!;
        public DbSet<ProductsCategories> productsCategories { get; set; } = null!;
       
    }

}
