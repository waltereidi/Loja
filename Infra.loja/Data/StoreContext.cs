using Dominio.loja.Entity;
using Dominio.loja.Entity.Integrations.WFileManager;
using Dominio.loja.Entity.Integrations.WFileManager.Relation;
using Dominio.loja.Events.FileUpload;
using Dominio.loja.Interfaces.Context;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
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
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseLazyLoadingProxies()
            //Place your own connection string here 
            .UseSqlServer("loja.Infra".GetConnectionString());

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

        //Files 
        public virtual DbSet<FileDirectory> fileDirectory { get; set; }
        public virtual DbSet<FileStorage> fileStorage { get; set; }
        public virtual DbSet<FileCategories> fileCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateCategoriesORM(modelBuilder);
            CreateFilesORM(modelBuilder);
            CreateFilesCategoriesORM(modelBuilder);
        }
        private void CreateFilesORM(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileDirectory>()
                .Property(e => e.Restriction)
                .HasConversion(
                    v => (string)v,
                    v => new DirectoryRestriction(v)
                );
            modelBuilder.Entity<FileStorage>()
               .Property(e => e.Id)
               .HasConversion(
                   v => v.ToString(),
                   v => new Guid(v)
               );
            modelBuilder.Entity<FileStorage>()
               .Property(e => e.FileProperties)
               .HasConversion(
                   v => (string)v,
                   v => new FileType(v)
               );

        }
        private void CreateFilesCategoriesORM(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileCategories>(entity =>
            {
                entity.HasOne(e => e.FileStorage)
                .WithOne()
                .HasForeignKey<FileCategories>(e => e.FileStorageId);
            });


            modelBuilder.Entity<FileCategories>(entity =>
            {
                entity
                .HasOne(e => e.Category)
                .WithOne()
                .HasForeignKey<FileCategories>(e => e.CategoriesId);
            });

        }

        private void CreateCategoriesORM(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubCategories>(entity =>
            {
                entity.HasOne(e => e.Categories)
                .WithOne()
                .HasForeignKey<SubCategories>(e => e.CategoriesId);

            });

            modelBuilder.Entity<SubSubCategories>(entity =>
            {
                entity.HasOne(e => e.SubCategories)
                .WithOne()
                .HasForeignKey<SubSubCategories>(e => e.SubCategoriesId);
            });

  
        }

      
    }
   
}
