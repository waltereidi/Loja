using Dominio.loja.Events.Praedicamenta;
using Framework.loja;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.loja.Entity
{
    [Table("categories")]
    public class Categories : Entity<int>
    {

        [StringLength(120)]
        
        public string Name { get; set; }
        [StringLength(2048)]
        public string? Description { get; set; }
        
        public Categories(Action<object> applier) :base(applier)
        {
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case PraedicamentaEvents.CreateCategory e:
                    Name = e.Name;
                    Description = e.Description;
                    break;
                default: throw new NotImplementedException();
            }

        }
    }


}
