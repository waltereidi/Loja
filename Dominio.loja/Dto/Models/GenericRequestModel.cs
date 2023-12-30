using Dominio.loja.Dto.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Dto.Models
{
    public class GenericRequestModel:MasterRequest
    {
        [System.Runtime.Versioning.SupportedOSPlatform("windows")]
        public object? GetObject(string? PathName = default, string? Class = default);
    }
}
