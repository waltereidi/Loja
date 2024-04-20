using Dominio.loja.Entity;
using Microsoft.EntityFrameworkCore;

namespace Dominio.loja.Interfaces.Context
{
    public interface IAdminControllerContext
    {
        DbSet<Clients> clients { get; set; }
    }
}
