
using Dominio.loja.Interfaces.Context;

namespace Dominio.loja.Entity
{
    public class Entity<TId> : IInternalEventHandler
        
    {
        public TId Id { get; protected set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }

        public void Handle(object @event)
        {
            throw new NotImplementedException();
        }
    }
}
