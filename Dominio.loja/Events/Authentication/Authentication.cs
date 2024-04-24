using Dominio.loja.Entity;
using Framework.loja;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Dominio.loja.Events.Authentication
{
    public class Authentication : AggregateRoot<int>
    {
        public LoginAdmin loginAdmin { get; set; }

        public Authentication(Clients clients , string issuer ,string jwtKey)
        {

        }

        protected override void EnsureValidState()
        {
            throw new NotImplementedException();
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}
