using Dominio.loja.Entity;
using Microsoft.EntityFrameworkCore;

namespace Api.loja.Data
{
    public abstract class StoreAdminContext : DbContext
    {

        private readonly string _connectionString;
        public StoreAdminContext(DbContextOptions<StoreAdminContext> options) : base(options)
        {

        }
        public StoreAdminContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
       
       
    }

}
