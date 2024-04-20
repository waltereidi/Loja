using Dominio.loja.Entity;
using Microsoft.EntityFrameworkCore;

namespace Dominio.loja.Interfaces.Context
{
    public interface IAdminStoreCategoriesControllerContext: IDbContext
    {
        DbSet<Categories> categories { get; set; }
        DbSet<SubCategories> subCategories { get; set; }
        DbSet<SubSubCategories> subSubCategories { get; set; }
    }
}
