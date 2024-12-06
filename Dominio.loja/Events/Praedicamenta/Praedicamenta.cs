using Dominio.loja.Entity;
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
        public Categories category { get; set; }
        public SubCategories subCategory { get; set; }
        public SubSubCategories subSubCategory { get; set; }

        public Praedicamenta(object @event)
        {
            
            Apply(@event);
        }
        public Praedicamenta()
        {
        }
        protected override void EnsureValidState()
        {

        }

        protected override void When(object @event)
        {
            switch(@event)
            {
                case PraedicamentaEvents.CreateCategory c :
                     category = new Categories();
                     ApplyToEntity(category , c);
                     break;
                case PraedicamentaEvents.CreateSubCategory c:
                     subCategory = new SubCategories();
                     ApplyToEntity(subCategory, c);
                     break;
                case PraedicamentaEvents.CreateSubSubCategory c:
                    subSubCategory = new SubSubCategories();
                    ApplyToEntity(subSubCategory , c);
                    break;
                case PraedicamentaEvents.UpdateCategory c:
                    category = new Categories();
                    ApplyToEntity(category , c);
                    break;
                case PraedicamentaEvents.UpdateSubCategory c:
                    subCategory = new SubCategories();
                    ApplyToEntity(subCategory, c);
                    break;
                case PraedicamentaEvents.UpdateSubSubCategory c:
                    subSubCategory = new SubSubCategories();
                    ApplyToEntity(subSubCategory, c);
                    break;

                default:throw new NotImplementedException();
            }
        }


    }
}
