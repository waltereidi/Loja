using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    public class Permissions
    {
        [Key]
        public int ID_Permissions { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
    }
}
