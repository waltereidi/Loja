
using Dominio.loja.Interfaces.Context;
using System.Reflection.Metadata;

namespace Dominio.loja.Entity
{
    public abstract class MasterEntity<TId> : IInternalEventHandler
       
    {
        private readonly Action<object> _applier;

        public TId Id { get; protected set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        protected MasterEntity(Action<object> applier) => _applier = applier;
        protected MasterEntity() { }
        protected abstract void When(object @event);
        protected void Apply(object @event)
        {
            When(@event);
            _applier(@event);
        }
        
        void IInternalEventHandler.Handle(object @event) => When(@event);
    }

}
