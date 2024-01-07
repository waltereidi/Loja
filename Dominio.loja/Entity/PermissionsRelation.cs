using Dominio.loja.Dto.CustomEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    [Table("permissionsRelation")]
    public class PermissionsRelation : Entity
    {
        [Key]
        public int PermissionsRelationId { get; set; }

        [ForeignKey("PermissionsGroupId")]
        public int PermissionsGroupId { get; set; }
        [ForeignKey("PermissionsId")]
        public int PermissionsId { get; set; }
        public virtual Permissions Permissions { get; set; }
        public virtual PermissionsGroup PermissionsGroup { get; set; }

    }
}
