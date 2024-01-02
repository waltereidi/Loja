using Dominio.loja.Dto.CustomEntities;
using Dominio.loja.Entity;
using Dominio.loja.Interfaces.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq;
namespace Api.loja.Data
{
    public class StoreContext : DbContext , IStoreClientsContext , IStoreProductsContext , IStoreContext
    {
        private readonly string _connectionString;
        public StoreContext()
        {
            _connectionString = "Server=MWALTR;Database=loja;Trusted_Connection=True;TrustServerCertificate=True;User Id=sa;Password=123";
        }
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }
        public StoreContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        public DbSet<Categories> categories { get; set; } = null!;
        public DbSet<CategoriesPromotion> categoryPromotion { get; set; } = null!;
        public DbSet<Clients> clients { get; set; }
        public DbSet<ClientsProductsCart> clientsProducts_cart { get; set; }= null!;
        private DbSet<Permissions> permissions { get; set; }
        private DbSet<PermissionsGroup> permissionsGroup { get; set; }
        private DbSet<PermissionsRelation> permissions_Relation { get; set; }
        public DbSet<Prices> prices { get; set; } = null!;
        public DbSet<Products> products { get; set; } = null!;
        public DbSet<ProductsCategories> productsCategories { get; set; } = null!;
        public DbSet<ProductsPrices> productsPrices { get; set; }= null!;
        public DbSet<ProductsStorage> productsStorage { get; set; } = null!;
        public DbSet<RequestOrders> requestOrders { get; set; } = null!;
        public DbSet<RequestOrdersProducts> requestOrdersProducts { get; set; } = null!;

    

    }

}
