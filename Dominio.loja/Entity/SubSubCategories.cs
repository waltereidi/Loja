using Dominio.loja.Events.Praedicamenta;
using Framework.loja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    public class SubSubCategories : Entity<int?>
    {
        public int SubCategoriesId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual SubCategories SubCategories { get; set; }

        public SubSubCategories(Action<object> applier) :base(applier){ }
        public SubSubCategories() { }
        protected override void When(object @event)
        {
            switch (@event)
            {
                case PraedicamentaEvents.CreateSubSubCategory c:
                    Name = c.Name;
                    Description = c.Description;
                    SubCategoriesId = c.SubCategory.Id ?? throw new ArgumentNullException(nameof(c.SubCategory.Id));
                    Created_at = DateTime.Now;
                    break;
                case PraedicamentaEvents.UpdateSubSubCategory c:
                    Name = c.name;
                    Description = c.description;
                    Updated_at = DateTime.Now;
                    break;
                default: throw new NotImplementedException();
            }

        }
    }
}
