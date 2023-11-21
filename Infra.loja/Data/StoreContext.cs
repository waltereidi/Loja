using Dominio.loja.Entity;
using Dominio.loja.Interfaces.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

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
        public DbSet<Permissions> permissions { get; set; }
        public DbSet<PermissionsRelation> permissionsRelation { get; set; }
        public DbSet<PermissionsGroup> permissionsGroup { get; set; }
        
        public Clients? getClient(string email, string password)
        {
            var Return=clients.Where(x => x.Email == email && x.Password == password);
            return Return.Any() ? Return.First() : null;
        }
        
        public List<PermissionsRelation> GetPermissionsRelation(string email)
        {
            var Return = permissionsRelation.Join(
                inner: permissionsGroup,
                outerKeySelector: pre => pre.ID_PermissionsGroup,
                innerKeySelector: peg => peg.ID_PermisionsGroup,
                (pre, peg) => new { PermissionsGroup = pre, permissionsGroup = peg }
                );

            return Return.Any() ? permissionsRelation.ToList() : null;
        }
    }

}
