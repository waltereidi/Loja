
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Api.loja.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options ) : base( options ) 
        {
           
        }
    }
}
