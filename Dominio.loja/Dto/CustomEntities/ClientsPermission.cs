using Dominio.loja.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Dto.CustomEntities
{
    public static class ClientsPermission
    {
        public static List<PermissionsRelation>? permissionsList { get; set; }
        public static Clients Clients { get; set; }

        public static string jwtToken { get; set; }

       

    }
}
