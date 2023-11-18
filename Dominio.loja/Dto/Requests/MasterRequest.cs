using Dominio.loja.Interfaces.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Dto.Requests
{
    private readonly IStoreContext _storeContext = new StoreContext();
    public class MasterRequest
    {
        public string Email { get; set; }


    }
}
