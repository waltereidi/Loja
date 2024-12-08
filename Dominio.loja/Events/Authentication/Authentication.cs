using Dominio.loja.Entity;
using Framework.loja;

namespace Dominio.loja.Events.Authentication
{
    public class Authentication : AggregateRoot<Guid>
    {
        
        public Clients Client { get; set; }
        public IPScore IPScore { get; set; }
        public Authentications Auth { get; set; }

        public Authentication()
        {
            base.Id = new Guid();
        }

        public Authentication(object @event)
        {
            base.Id = new Guid();
            Apply( @event);
        }

        protected override void EnsureValidState()
        {
            if (Client == null || IPScore == null || Auth != null)
                throw new ArgumentException();

            //if(IPScore.IPAddress.ToString() == Auth.IpAddress.ToString())
            //{

            //}
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case AuthenticationEvents.Request.LoginAdmin @e: HandleAuthenticationAdmin(@e); break;
            }
        }
        
        private void HandleAuthenticationAdmin(AuthenticationEvents.Request.LoginAdmin e)
        {

            if (e.IPScore == null)
            {
                IPScore = new IPScore(Apply);
                ApplyToEntity(IPScore, new AuthenticationEvents.Request.CreateIpScore(e.context.Ip));
            } else
                IPScore = e.IPScore;


            if (e.auth.Any(x => e.client.Id == x.ClientId ))
            {

            }

        }

        



    }
}
