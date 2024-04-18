using Dominio.loja.Entity;
using Dominio.loja.Entity.Integrations.WFileManager;
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
		private void CreateCategoriesORM(ModelBuilder modelBuilder)
		{
            //Categories Promotion
            modelBuilder.Entity<CategoriesPromotion>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.HasOne(e => e.Categories)
				.WithOne()
				.HasForeignKey<CategoriesPromotion>(e => e.Id)
				.HasPrincipalKey<Categories>(e => e.Id).OnDelete(DeleteBehavior.Restrict);
			});
			modelBuilder.Entity<Categories>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.HasMany(e => e.SubCategories)
				.WithOne()
				.HasForeignKey(e => e.Id)
				.HasPrincipalKey(e => e.Id);
			});
			modelBuilder.Entity<SubCategories>(entity => 
			{
				entity.HasKey(e=> e.Id);

				entity.HasMany(e => e.SubSubCategories)
				.WithOne()
				.HasForeignKey(e => e.Id)
				.HasPrincipalKey(e => e.Id);
			});
			modelBuilder.Entity<CategoriesPromotion>(entity =>
			{
				entity.HasKey(e => e.Id) ;

				entity.HasMany(e => e.ProductsCategories)
				.WithOne()
				.HasForeignKey(e => e.CategoriesId)
				.HasPrincipalKey(e=> e.Id);
			});
		}
		public virtual DbSet<Clients> clients { get; set; }
		public virtual DbSet<ClientsProductsCart> clientsProducts_cart { get; set; }
		public virtual DbSet<Permissions> permissions { get; set; }
		public virtual DbSet<PermissionsGroup> permissionsGroup { get; set; }
		public virtual DbSet<PermissionsRelation> permissions_Relation { get; set; }
		public void CreateClientsORM(ModelBuilder modelBuilder)
		{
			//Clients
			modelBuilder.Entity<Clients>(entity =>
			{
				entity.Property(e => e.Email).IsConcurrencyToken();
                entity.HasOne(e => e.PermissionsGroup)
				.WithOne()
				.HasForeignKey<PermissionsGroup>(e=> e.Id);

				entity.HasMany(e => e.ClientsProductsCart)
				.WithOne()
				.HasForeignKey(e => e.ClientsId);
			});
			//PermissionsGroup
			modelBuilder.Entity<PermissionsGroup>(entity =>
			{
				entity.HasKey(e=> e.Id);
				entity.HasMany(e => e.PermissionsRelations)
				.WithOne()
				.HasForeignKey(e => e.PermissionsGroupId);
			});
			//PermissionsRelation
			modelBuilder.Entity<PermissionsRelation>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.HasOne(e => e.Permissions)
				.WithOne()
				.HasForeignKey<Permissions>(e => e.Id);
			});
			
		}
		public virtual DbSet<Products> products { get; set; }
		public virtual DbSet<ProductsCategories> productsCategories { get; set; }
		public virtual DbSet<Prices> prices { get; set; }
		public virtual DbSet<ProductsPrices> productsPrices { get; set; } = null!;
		public virtual DbSet<ProductsStorage> productsStorage { get; set; } = null!;
		private void CreateProductsORM(ModelBuilder modelBuilder)
		{
			//Products
			modelBuilder.Entity<Products>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.HasOne(e => e.ProductsCategories)
				.WithOne()
				.HasForeignKey<ProductsCategories>(e => e.ProductsId);

				entity.HasOne(e => e.ProductsSubCategories)
				.WithOne()
				.HasForeignKey<ProductsSubCategories>(e => e.ProductsId);

				entity.HasOne(e => e.ProductsSubSubCategories)
				.WithOne()
				.HasForeignKey<ProductsSubSubCategories>(e => e.ProductsId);
			});
			modelBuilder.Entity<ProductsCategories>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.HasOne(e => e.Products)
				.WithOne(e => e.ProductsCategories)
				.HasForeignKey<Products>(e => e.Id)
				.HasPrincipalKey<ProductsCategories>(e=> e.ProductsId);
			});
		
		}
		public virtual DbSet<RequestOrders> requestOrders { get; set; } = null!;
		public virtual DbSet<RequestOrdersProducts> requestOrdersProducts { get; set; }
		
		private void CreateRequestORM(ModelBuilder modelBuilder)
		{
			//RequestOrders 
			modelBuilder.Entity<RequestOrders>(entity =>
			{
				entity.HasKey(e=> e.Id);

				entity.HasMany(e => e.RequestOrdersProducts)
				.WithOne()
				.HasForeignKey(e=> e.RequestOrdersId);
			});
			//RequestOrders Products
			modelBuilder.Entity<RequestOrdersProducts>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.HasOne(e => e.Products)
				.WithOne()
				.HasForeignKey<Products>(e=>e.Id);
			});
            //ClientsProductsCart 
            modelBuilder.Entity<ClientsProductsCart>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Products)
                .WithOne()
                .HasForeignKey<Products>(e => e.Id);
            });
        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			CreateCategoriesORM(modelBuilder);
			CreateProductsORM(modelBuilder);
			CreateRequestORM(modelBuilder);
            CreateFileManagerORM(modelBuilder);
        }
		public virtual DbSet<FileDirectory> fileDirectory { get; set; } = null;
		public virtual DbSet<FileStorage> fileStorage { get; set; } = null;

        private void CreateFileManagerORM(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<FileStorage>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.HasOne(e => e.Directory)
				.WithOne()
				.HasForeignKey<FileDirectory>(e => e.Id);
			});
        }
    }
    
}
