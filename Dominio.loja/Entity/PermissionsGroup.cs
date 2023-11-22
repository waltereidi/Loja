using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    public class PermissionsGroup
    {
        [Key]
        public int ID_PermissionsGroup { get; set; }

        [StringLength(255)]
        public string Name {  get; set; }

    }
}
