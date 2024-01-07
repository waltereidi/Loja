using Dominio.loja.Entity;
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
		private  void CreateCategoriesORM(ModelBuilder modelBuilder)
		{
			//Categories Promotion
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
		public void CreateClientsORM(ModelBuilder modelBuilder)
		{
			//Clients
			modelBuilder.Entity<Clients>(entity =>
			{
				entity.HasKey(e=> e.ClientsId);
				entity.HasOne(e => e.PermissionsGroup)
				.WithOne()
				.HasForeignKey<PermissionsGroup>(e=> e.PermissionsGroupId);
			});
			//PermissionsGroup
			modelBuilder.Entity<PermissionsGroup>(entity =>
			{
				entity.HasKey(e=> e.PermissionsGroupId);
				entity.HasMany(e => e.PermissionsRelations)
				.WithOne()
				.HasForeignKey(e => e.PermissionsRelationId);
			});
			//PermissionsRelation
			modelBuilder.Entity<PermissionsRelation>(entity =>
			{
				entity.HasKey(e => e.PermissionsRelationId);

				entity.HasOne(e => e.Permissions)
				.WithOne()
				.HasForeignKey<Permissions>(e => e.PermissionsId);

				entity.HasOne(e => e.PermissionsGroup)
				.WithOne()
				.HasForeignKey<PermissionsGroup>(e => e.PermissionsGroupId);
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
				entity.HasKey(e => e.ProductsId);
				entity.HasOne(e => e.ProductsCategories)
				.WithOne()
				.HasForeignKey<ProductsCategories>(e => e.ProductsId);

				entity.HasMany(e => e.ProductsPrices)
				.WithOne(e => e.Products)
				.HasForeignKey(e => e.ProductsPriceId);

				entity.HasMany(e => e.ProductsStorage)
				.WithOne()
				.HasForeignKey(e => e.ProductsId);
			});
			//Products Categories
			modelBuilder.Entity<ProductsCategories>(entity =>
			{
				entity.HasKey(e => e.ProductsCategoriesId);
				
				entity.HasOne(e => e.Products)
				.WithOne()
				.HasForeignKey<Products>(e => e.ProductsId);

				entity.HasOne(e => e.Categories)
				.WithOne()
				.HasForeignKey<Categories>(e => e.CategoriesId);
			});
		}
		

		public virtual DbSet<RequestOrders> requestOrders { get; set; } = null!;
		public virtual DbSet<RequestOrdersProducts> requestOrdersProducts { get; set; }
		
		private void CreateRequestORM(ModelBuilder modelBuilder)
		{
			//RequestOrders 
			modelBuilder.Entity<RequestOrders>(entity =>
			{
				entity.HasKey(e=> e.RequestOrdersId);

				entity.HasMany(e => e.RequestOrdersProducts)
				.WithOne()
				.HasForeignKey(e=> e.RequestOrdersProductsId);
			});
			//RequestOrders Products
			modelBuilder.Entity<RequestOrdersProducts>(entity =>
			{
				entity.HasKey(e => e.RequestOrdersProductsId);

				entity.HasOne(e => e.Products)
				.WithOne()
				.HasForeignKey<Products>(e=>e.ProductsId);
			});
            //ClientsProductsCart 
            modelBuilder.Entity<ClientsProductsCart>(entity =>
            {
                entity.HasKey(e => e.ClientsProductsCartId);
                entity.HasOne(e => e.Products)
                .WithOne()
                .HasForeignKey<Products>(e => e.ProductsId);

                entity.HasOne(e => e.Clients)
                .WithOne()
                .HasForeignKey<Clients>(e => e.ClientsId);
            });
        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			CreateCategoriesORM(modelBuilder);
			CreateProductsORM(modelBuilder);
			CreateRequestORM(modelBuilder);        
		}
	   
	}
    
}
