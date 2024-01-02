﻿using Dominio.loja.Entity;
using Dominio.loja.Interfaces.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;


namespace Api.loja.Data
{
    public class StoreContext : DbContext , IStoreClientsContext , IStoreProductsContext , IStoreContext
    {
        private readonly string _connectionString;
        public StoreContext()
        {
            string dir = Directory.GetCurrentDirectory();
            string jsonDir = dir.Replace("\\Tests.Loja\\bin\\Debug\\net6.0", "") + "\\Api.loja\\appsettings.json";
            string json = File.ReadAllText(jsonDir);
            dynamic launchSettings = JObject.Parse(json);
            _connectionString = (string)launchSettings.ConnectionString;
        }
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseLazyLoadingProxies().UseSqlServer(_connectionString);

        public virtual DbSet<Categories> categories { get; set; }
        public virtual DbSet<CategoriesPromotion> categoriesPromotion { get; set; }
        private  void CategoriesORM(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriesPromotion>(entity =>
            {
                entity.HasKey(e => e.CategoriesPromotionId);

                entity.HasOne(e => e.Categories)
                .WithOne()
                .HasForeignKey<CategoriesPromotion>(e => e.CategoriesId)
                .HasPrincipalKey<Categories>(e => e.CategoriesId).OnDelete(DeleteBehavior.Restrict);
            });
            
       
        }
        public virtual DbSet<Clients> clients { get; set; }
        public virtual DbSet<ClientsProductsCart> clientsProducts_cart { get; set; }
        public virtual DbSet<Permissions> permissions { get; set; }
        public virtual DbSet<PermissionsGroup> permissionsGroup { get; set; }
        public virtual DbSet<PermissionsRelation> permissions_Relation { get; set; }
        
        public virtual DbSet<Products> products { get; set; }
        public virtual DbSet<ProductsCategories> productsCategories { get; set; }
        public virtual DbSet<Prices> prices { get; set; }
        private void CreateProductsORM(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductsId);
                entity.HasOne(e => e.ProductsCategories)
                .WithOne()
                .HasForeignKey<ProductsCategories>(e => e.ProductsId);
            });
            modelBuilder.Entity<ProductsCategories>(entity =>
            {
                entity.HasKey(e => e.ProductsCategoriesId);
                
                entity.HasOne(e => e.Products)
                .WithOne()
                .HasForeignKey<ProductsCategories>(e => e.ProductsId);

                entity.HasOne(e => e.Categories)
                .WithOne()
                .HasForeignKey<ProductsCategories>(e => e.CategoriesId);
            });
        }
        
        public virtual DbSet<ProductsPrices> productsPrices { get; set; }= null!;
        public virtual DbSet<ProductsStorage> productsStorage { get; set; } = null!;
        public virtual DbSet<RequestOrders> requestOrders { get; set; } = null!;
        public virtual DbSet<RequestOrdersProducts> requestOrdersProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CategoriesORM(modelBuilder);
            
        }
       
    }

}
