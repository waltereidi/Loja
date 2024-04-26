using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Events.Authentication
{
    public static class AuthenticationEvents
    {
        public record class LoginAdminRequest(LoginAdmin loginAdmin);
    }
}
