using Framework.loja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Events.Praedicamenta
{
    public class Praedicamenta : AggregateRoot<int>
    {
        public Praedicamenta(object @event)
        {
            Apply(@event);
        }

        protected override void EnsureValidState()
        {
            throw new NotImplementedException();
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case PraedicamentaEvents.CreateCategory c: 
                    
                    ;break; 
            
            }
        }
    }
}
