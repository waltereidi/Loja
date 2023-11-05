using Dominio.loja.Entity;
using Dominio.loja.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.loja.Data
{
    public class StoreContext : DbContext, IStoreContext
    {
        public StoreContext()
        {

        }
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }
        public virtual DbSet<Clients> Clients { get; set; }

        public Clients? getClient(string email, string password)
        {
            return Clients.Where(x => x.Email == email && x.Password == password).First();
        }

       
    }

}
