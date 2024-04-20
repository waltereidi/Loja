using Dominio.loja.Entity;
using Microsoft.EntityFrameworkCore;


namespace Dominio.loja.Interfaces.Context
{
    public interface IStoreClientsControllerContext : IDbContext
    {
        DbSet<Clients> clients { get; set; }
        DbSet<Products> products { get; set; }
        DbSet<ProductsCategories> productsCategories { get; set; }
        DbSet<ProductsPrices> productsPrices { get; set; }
        DbSet<ProductsStorage> productsStorage { get; set; }
        DbSet<Categories> categories { get; set; }
        DbSet<Prices> prices { get; set; }
        DbSet<ClientsProductsCart> clientsProducts_cart { get; set; }
        DbSet<RequestOrders> requestOrders { get; set; }
        DbSet<RequestOrdersProducts> requestOrdersProducts { get; set; }

    }
}
