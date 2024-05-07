using Dominio.loja.Events.Praedicamenta;
using Framework.loja;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    [Table("SubCategories")]
    public class SubCategories : Entity<int?>
    {

        [StringLength(30)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoriesId { get; set; }
        public virtual Categories Categories { get; set; }
        
        public SubCategories(Action<object> applier) : base(applier) { }
        
        public SubCategories() { }
        protected override void When(object @event)
        {
            switch (@event)
            {
                case PraedicamentaEvents.CreateSubCategory c:
                    Name = c.Name;
                    Description = c.Description;
                    CategoriesId = c.Category.Id ?? throw new ArgumentNullException(nameof(c.Category.Id));
                    Categories = c.Category;
                    Created_at = DateTime.Now;
                    break;
                case PraedicamentaEvents.UpdateSubCategory c:
                    Name = c.name;
                    Description = c.description;
                    CategoriesId = c.Category.Id ?? throw new ArgumentNullException(nameof(c.Category.Id));
                    Categories = c.Category;
                    Updated_at = DateTime.Now;
                    break;
                default: throw new NotImplementedException();
            }

        }
    }
}
