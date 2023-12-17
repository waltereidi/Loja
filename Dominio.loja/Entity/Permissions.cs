using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    [Table("permissions")]
    public class Permissions
    {
        [Key]
        public int ID_Permissions { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
    }
}
