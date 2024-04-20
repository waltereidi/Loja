using Framework.loja.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Framework.loja
{
    public abstract class AggregateRoot<TId> : IInternalEventHandler
    {
        public TId Id { get; protected set; }

        protected abstract void When(object @event);

        private readonly List<object> _changes;

        protected AggregateRoot() => _changes = new List<object>();

        protected void Apply(object @event)
        {
            When(@event);
            EnsureValidState();
            _changes.Add(@event);
        }

        public IEnumerable<object> GetChanges() => _changes.AsEnumerable();

        public void ClearChanges() => _changes.Clear();

        protected abstract void EnsureValidState();

        protected void ApplyToEntity(IInternalEventHandler entity, object @event)
            => entity?.Handle(@event);

        void IInternalEventHandler.Handle(object @event) => When(@event);

    }
}
