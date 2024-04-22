using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Framework.loja.Dto.Models
{
    public class ControllerResponse<T> where T : class
    {
        public HttpStatusCode StatusCode { get; set; }
        public T Response { get; set; }
    }
}
