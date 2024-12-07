using Dominio.loja.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Events.Authentication
{
    public static class AuthenticationEvents
    {
        public class Request()
        {
            public record class LoginAdmin(Clients client )
        }
        public class Response()
        {
            public record class LoginAdmin(LoginAdmin loginAdmin);
        }
        
    }
}
