using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Dominio.loja.Interfaces.Context
{
    public interface IDbContext
    {
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken);
        EntityEntry Update(object entity);
        EntityEntry Remove(object entity);
        void Dispose();
        ValueTask DisposeAsync();
        Task AddRangeAsync(object[] entities);
        void AddRange(object[] entities);
        void RemoveRange(object[] entities);
    }
}
