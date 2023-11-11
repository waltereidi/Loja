using Dominio.loja.Entity;
using Dominio.loja.Interfaces.Context;
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
        public DbSet<Clients> clients { get; set; }

        public Clients? getClient(string email, string password)
        {

            var retorno =clients.Where(x => x.Email == email && x.Password == password);
            return retorno.Any() ? retorno.First() : null;
        }
        

       
    }

}
