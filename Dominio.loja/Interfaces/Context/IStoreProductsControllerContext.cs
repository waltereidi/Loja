using Dominio.loja.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
