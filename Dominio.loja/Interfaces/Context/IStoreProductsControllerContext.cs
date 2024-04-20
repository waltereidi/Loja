using Dominio.loja.Entity;
using Microsoft.EntityFrameworkCore;

namespace Dominio.loja.Interfaces.Context
{
    public interface IStoreProductsControllerContext :IDbContext 
    {
         DbSet<Categories> categories { get; set; } 
         DbSet<Prices> prices { get; set; } 
         DbSet<Products> products { get; set; }
         DbSet<CategoriesPromotion> categoriesPromotion { get; set; } 
         DbSet<ProductsCategories> productsCategories { get; set; }


    }
}
