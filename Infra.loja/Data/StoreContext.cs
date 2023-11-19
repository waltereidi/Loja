using Dominio.loja.Entity;
using Dominio.loja.Interfaces.Context;
using Microsoft.AspNetCore.Authorization;
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
        public DbSet<PermissionsRelation> permissionsRelation { get; set; }
        
        public Clients? getClient(string email, string password)
        {
            var Return=clients.Where(x => x.Email == email && x.Password == password);
            return Return.Any() ? Return.First() : null;
        }
        
        public List<PermissionsRelation> GetPermissionsRelation(string email)
        {
            //var Return = (from prr in permissionsRelation
            //                             join cli in this.clients on clients..ID_Clients equals c.Id
            //                             join pr in _context.Prices on p.Price_id equals pr.Id
            //                             select new
            //                             {
            //                                 p.Id
            //                             });
            return new List<PermissionsRelation>();
        }
    }

}
