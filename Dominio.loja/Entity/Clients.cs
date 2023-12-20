using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    [Table("clients")]
    public class Clients : MasterEntity
    {
        [Key]
        public int ID_Clients { get; set; }

        [StringLength(320)]
        public string Email { get; set; }

        [StringLength(30)]
        public string Password { get; set; }
        [ForeignKey("ID_PermissionsGroup")]
        public int ID_PermissionsGroup { get; set; }
        [NotMapped]
        public PermissionsGroup? PermissionsGroup { get; set; }

    }
}
