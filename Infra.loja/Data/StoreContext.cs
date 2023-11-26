using Dominio.loja.Dto.CustomEntities;
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
        public virtual DbSet<Clients> clients { get; set; }
        public virtual DbSet<Permissions> permissions { get; set; }
        public virtual DbSet<PermissionsRelation> permissions_Relation { get; set; }
        public virtual DbSet<PermissionsGroup> permissionsGroup { get; set; }
        
        public Clients? getClient(string email, string password)
        {
            var Return=clients.Where(x => x.Email == email && x.Password == password);
            return Return.Any() ? Return.First() : null;
        }
        
        public void GetPermissionsRelation(string email )
        {
            var query = from perR in permissions_Relation
                 join perG in permissionsGroup on perR.ID_Permissions_Relation equals perG.ID_PermissionsGroup 
                 join cli in clients on perG.ID_PermissionsGroup equals cli.ID_PermissionsGroup
                 join per in permissions on perR.ID_Permissions equals per.ID_Permissions
                 where cli.Email == email 
                 select new PermissionsRelation() { 
                    PermissionsGroup = perG ,
                    Permissions = per ,
                    Created_at = perR.Created_at,
                    Updated_at = perR.Updated_at,
                 };

            ClientsPermission.permissionsList = query.Any() ? query.ToList() : null; 
        }
    }

}
