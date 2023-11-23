using Dominio.loja.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Dto.CustomEntities
{
    public class ClientsPermission
    {
        public Clients clients { get; set; }
        public PermissionsGroup permissionsGroup { get; set; }
        public List<PermissionsRelation> permissionsRelation { get; set; }
        public List<Permissions> permissions { get; set; }



    }
}
