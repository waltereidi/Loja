using Framework.loja.Interfaces;
using System.Reflection;

namespace Framework.loja
{
    public abstract class Entity<TId> : IInternalEventHandler
    {
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        private readonly Action<object> _applier;
        public TId Id { get; set; }
        //Constructor used to receive an event
        protected Entity(Action<object> applier) 
        {
            _applier = applier;
        } 

        protected Entity() 
        {
        }
        protected abstract void When(object @event);
        protected void Apply(object @event)
        {
            SetEntityTime();

            When(@event);
            //This applier comes from domain IAggregateRoot
            //A method from IAggregate root can be triggered to ensure domain constraints from multiple sources after every 
            //entity event

            ValidateAttributes();
            
            _applier(@event);
        }
        public virtual void SetEntityTime()
        {
            if(Created_at.Year > 2000 )
                Created_at = DateTime.Now; 
            else
                Updated_at = DateTime.Now;
        }
        void IInternalEventHandler.Handle(object @event) => When(@event);
        protected void ValidateAttributes()
        {
            var assembly = Attribute.GetCustomAttributes(Assembly.GetExecutingAssembly());
        }
    }
}
