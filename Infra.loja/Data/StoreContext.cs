using Dominio.loja.Entity;
using Dominio.loja.Interfaces.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq;
namespace Api.loja.Data
{
    public class StoreContext : DbContext, IStoreContext
    {
        private readonly string _connectionString;
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }
        public StoreContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        public DbSet<Clients> clients { get; set; }
        public DbSet<Permissions> permissions { get; set; }
        public DbSet<PermissionsRelation> permissions_Relation { get; set; }
        public DbSet<PermissionsGroup> permissionsGroup { get; set; }
        
        public Clients? getClient(string email, string password)
        {
            var Return=clients.Where(x => x.Email == email && x.Password == password);
            return Return.Any() ? Return.First() : null;
        }
        
        public List<PermissionsRelation> GetPermissionsRelation(string email)
        {
            var Return = permissions_Relation.Join(
                inner: permissionsGroup,
                outerKeySelector: pre => pre.ID_PermissionsGroup,
                innerKeySelector: peg => peg.ID_PermissionsGroup,
                (pre, peg) => new PermissionsRelation() { 
                    Created_at=pre.Created_at ,
                    Updated_at=pre.Updated_at ,
                    PermissionsGroup = peg 
                }
                );

            var query = (
             from perR in permissions_Relation
             join perG in permissionsGroup on perR.ID_Permissions_Relation equals perG.ID_PermissionsGroup
             select new {perR , perG}
             
             );
            var i = query.ToList();


            return Return.Any() ? Return.ToList() : null;
        }
    }

}
