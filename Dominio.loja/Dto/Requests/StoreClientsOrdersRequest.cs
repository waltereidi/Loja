using Dominio.loja.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Dto.Requests
{
    public class StoreClientsOrdersRequest : MasterRequest
    {
        public FilterOrder FilterOrder { get; set; }
    }
}
