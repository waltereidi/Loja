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
    public class PermissionsRelation : MasterEntity
    {
        [Key]
        public int ID_Permissions_Relation { get; set; }

        [ForeignKey("ID_PermissionsGroup")]
        public int ID_PermissionsGroup { get; set; }
        [ForeignKey("ID_Permissions")]
        public int ID_Permissions { get; set; }
        [NotMapped]
        public PermissionsGroup PermissionsGroup { get; set; }
        [NotMapped]
        public Permissions Permissions { get; set; }

    }
}
