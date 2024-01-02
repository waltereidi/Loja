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
    public class PermissionsGroup
    {
        [Key]
        public int PermissionsGroupId { get; set; }

        [StringLength(255)]
        public string Name {  get; set; }

    }
}
