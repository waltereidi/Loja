using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    public class PermissionsRelation : MasterEntity 
    {
        [Key]
        public int ID_PermissionsRelation { get; set; }
        [Key]
        public int ID_PermissionsGroup { get; set; }
        [Key]
        public int ID_Permissions { get; set; }

        PermissionsGroup PermissionsGroup { get; set; }
        Permissions Permissions { get; set; }


    }
}
