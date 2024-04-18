
using Dominio.loja.Interfaces.Context;
using System.Reflection.Metadata;

namespace Dominio.loja.Entity
{
    public abstract class MasterEntity<TId> : IInternalEventHandler
       
    {
        private readonly Action<object> _applier;
        private readonly List<object> _changes;
        public TId Id { get; protected set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        protected MasterEntity() => _changes = new();
        protected void Apply(object @event)
        {
            When(@event);
            EnsureValidState();
            _changes.Add(@event);
        }
        protected abstract void When(object @event);
        protected abstract void EnsureValidState();
        protected void ApplyToEntity(IInternalEventHandler entity, object @event) => entity?.Handle(@event);
        public IEnumerable<object> GetChanges() => _changes.AsEnumerable();
        void IInternalEventHandler.Handle(object @event) => When(@event);
    }

}
