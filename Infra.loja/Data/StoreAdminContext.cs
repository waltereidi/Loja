using Dominio.loja.Entity;
using Microsoft.EntityFrameworkCore;
using WConnectionKeyVault;

namespace Api.loja.Data
{
    public class StoreAdminContext : DbContext
    {

        public StoreAdminContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseLazyLoadingProxies().UseSqlServer("loja.Infra".GetConnectionString());


    }

}
