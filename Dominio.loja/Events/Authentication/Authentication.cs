using Dominio.loja.Entity;
using Framework.loja;


namespace Dominio.loja.Events.Authentication
{
    public class Authentication : AggregateRoot<Guid>
    {
        public LoginAdmin loginAdmin { get; set; }

        public Authentication()
        {

        }

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
