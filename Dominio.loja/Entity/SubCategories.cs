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
    public class SubCategories : Entity<int>
    {

        [StringLength(30)]
        public string Name { get;set;}
        public string Description { get; set; }
        public int CategoriesId { get;set;}
        public virtual Categories Categories { get;set;}
        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}
