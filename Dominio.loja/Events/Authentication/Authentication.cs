using Dominio.loja.Entity;
using Framework.loja;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dominio.loja.Events.Authentication
{
    public class Authentication : AggregateRoot<int>
    {
        public LoginAdmin loginAdmin { get; set; }

        public Authentication(Clients clients , string issuer ,string jwtKey)
        {
            var client = new LoginAdmin(clients, issuer, jwtKey);
            Apply( new AuthenticationEvents.LoginAdminRequest(client));

        }

        protected override void EnsureValidState()
        {
            ArgumentNullException.ThrowIfNull(loginAdmin.Token);
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case AuthenticationEvents.LoginAdminRequest @e: loginAdmin = @e.loginAdmin; break;
            }
        }
   
    }
}
