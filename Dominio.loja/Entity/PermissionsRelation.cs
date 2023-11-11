using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    public class PermissionsRelation : MasterEntity 
    {
        PermissionsGroup PermissionsGroup { get; set; }
        Permissions Permissions { get; set; }

    }
}
