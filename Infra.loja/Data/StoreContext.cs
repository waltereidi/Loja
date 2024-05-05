using Dominio.loja.Entity;
using Dominio.loja.Entity.Integrations.WFileManager;
using Dominio.loja.Events.Praedicamenta;
using Dominio.loja.Interfaces.Context;
using Microsoft.EntityFrameworkCore;
using WConnectionKeyVault;

namespace Api.loja.Data
{
	public class StoreContext : DbContext ,
		IStoreClientsControllerContext ,
		IStoreProductsControllerContext ,
		IStoreControllerContext,
		IAdminControllerContext, 
		IAdminStoreCategoriesControllerContext
    {
		public StoreContext()
		{
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseLazyLoadingProxies().UseSqlServer("loja.Infra".GetConnectionString());
		public virtual DbSet<Categories> categories { get; set; }
        public virtual DbSet<SubCategories> subCategories { get; set; }
        public virtual DbSet<SubSubCategories> subSubCategories { get; set; }
        public virtual DbSet<CategoriesPromotion> categoriesPromotion { get; set; }
		public virtual DbSet<Clients> clients { get; set; }
		public virtual DbSet<ClientsProductsCart> clientsProducts_cart { get; set; }
		public virtual DbSet<Permissions> permissions { get; set; }
		public virtual DbSet<PermissionsGroup> permissionsGroup { get; set; }
		public virtual DbSet<PermissionsRelation> permissions_Relation { get; set; }
		public virtual DbSet<Products> products { get; set; }
		public virtual DbSet<ProductsCategories> productsCategories { get; set; }
		public virtual DbSet<Prices> prices { get; set; }
		public virtual DbSet<ProductsPrices> productsPrices { get; set; } = null!;
		public virtual DbSet<ProductsStorage> productsStorage { get; set; } = null!;
		public virtual DbSet<RequestOrders> requestOrders { get; set; } = null!;
		public virtual DbSet<RequestOrdersProducts> requestOrdersProducts { get; set; }
		public virtual DbSet<FileDirectory> fileDirectory { get; set; } = null;
		public virtual DbSet<FileStorage> fileStorage { get; set; } = null;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateCategoriesORM(modelBuilder);
        }

        void CreateCategoriesORM(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubCategories>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Categories)
                .WithOne()
                .HasForeignKey<Categories>(e => e.Id);
            });

            modelBuilder.Entity<SubSubCategories>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.SubCategories)
                .WithOne()
                .HasForeignKey<SubCategories>(e => e.Id);
            });
        }

      
    }
   
}
