using Dominio.loja.Entity;
using Microsoft.EntityFrameworkCore;

namespace Api.loja
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options ) : base( options ) 
        {
           
        }
        public virtual DbSet<Category> Category { get; set; } = null!;
        public virtual DbSet<Products> Products { get; set; } = null!;
        public virtual DbSet<Prices> Prices { get; set; } = null!;

    }
}
