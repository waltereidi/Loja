
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Dto.Requests.AdminControllerRequests
{
    public record class LoginRequest(string Email , string Password);
}
