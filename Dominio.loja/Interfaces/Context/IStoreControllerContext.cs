using Dominio.loja.Entity;
using Microsoft.EntityFrameworkCore;


namespace Dominio.loja.Interfaces.Context
{
    public interface IStoreControllerContext : IDbContext
    {
        DbSet<Clients> clients { get; set; }

    }
}
