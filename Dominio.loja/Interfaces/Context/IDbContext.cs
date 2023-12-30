using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Interfaces.Context
{
    public interface IDbContext
    {
        int SaveChanges();
        EntityEntry Update(object entity);

        EntityEntry Delete(object entity);
        EntityEntry Add(object entity);

    }
}
