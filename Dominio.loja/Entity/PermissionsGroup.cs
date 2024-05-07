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
    [Table("permissionsGroup")]
    public class PermissionsGroup : Entity<int?>
    {


        [StringLength(255)]
        public string Name {  get; set; }

        public virtual ICollection<PermissionsRelation> PermissionsRelations { get; set; }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}
