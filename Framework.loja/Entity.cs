using Framework.loja.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Framework.loja
{
    public abstract class Entity<TId> : IInternalEventHandler
    {
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        private readonly Action<object> _applier;
        public TId Id { get; set; }
        //Constructor used to receive an event
        protected Entity(Action<object> applier) => _applier = applier;

        protected Entity() { }
        protected abstract void When(object @event);
        protected void Apply(object @event)
        {
            When(@event);
            _applier(@event);
        }
        void IInternalEventHandler.Handle(object @event) => When(@event);
    }
}
