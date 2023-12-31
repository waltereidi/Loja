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
        public DbSet<CategoryPromotion> categoryPromotion { get; set; } = null!;
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

        public void SetPermissionsRelation(string email )
        {
            var query = from perR in permissions_Relation
                 join perG in permissionsGroup on perR.ID_Permissions_Relation equals perG.ID_PermissionsGroup 
                 join cli in clients on perG.ID_PermissionsGroup equals cli.ID_PermissionsGroup
                 join per in permissions on perR.ID_Permissions equals per.ID_Permissions
                 where cli.Email == email 
                 select new PermissionsRelation() { 
                    PermissionsGroup = perG ,
                    Permissions = per ,
                    Created_at = perR.Created_at,
                    Updated_at = perR.Updated_at,
                 };
            ClientsPermission.permissionsList = query.Any() ? query.ToList() : null; 
        }

    }

}
