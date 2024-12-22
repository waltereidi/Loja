using Framework.loja.Interfaces;
using System.Reflection;
using System.Runtime.Serialization;

namespace Framework.loja
{
    public abstract class Entity<TId> : IInternalEventHandler
    {
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        private readonly Action<object> _applier;
        public TId Id { get; set; }
        [IgnoreDataMember]
        public List<object> _changes = new List<object>();
        //Constructor used to receive an event
        protected Entity(Action<object> applier)
        {
            _applier = applier;
        }

        protected Entity()
        {

        }
        protected virtual void ApplyToEntity(object @event)
        {

        }
        protected abstract void When(object @event);
        protected void Apply(object @event)
        {
            _changes.Add(@event);

            SetEntityTime();

            When(@event);
            //This applier comes from domain IAggregateRoot
            //A method from IAggregate root can be triggered to ensure domain constraints from multiple sources after every 
            //entity event

            _applier(@event);
        }
        protected virtual void SetEntityTime()
        {
            if (Created_at.Year < 2000)
                Created_at = DateTime.Now;
            else
                Updated_at = DateTime.Now;
        }
        void IInternalEventHandler.Handle(object @event)
        {
            _changes.Add(@event);

            SetEntityTime();
            When(@event);
                
        }

    }
}
