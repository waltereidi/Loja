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

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }


}
