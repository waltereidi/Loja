using Dominio.loja.Dto.CustomEntities;
using Dominio.loja.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Interfaces.Context
{
    public interface IStoreContext : IDbContext
    {
        DbSet<Products> products { get; set; }
        DbSet<ProductsCategories> productsCategories { get; set; }
        DbSet<ProductsPrices> productsPrices { get; set; }
        DbSet<ProductsStorage> productsStorage { get; set; }
        DbSet<Categories> categories { get; set; }
        DbSet<Prices> prices { get; set; }
        DbSet<Clients> clients { get; set; }
        DbSet<ClientsProductsCart> clientsProducts_cart { get; set; }
        DbSet<RequestOrders> requestOrders { get; set; }
        DbSet<RequestOrdersClientsProductsCart> requestOrdersClientsProductsCart { get; set; }
        IQueryable<GetRequestOrdersDTO> GetOrdersRequest(int ID_Clients);
        IQueryable<ClientsProductsCart> GetCartProducts();

    }
}
