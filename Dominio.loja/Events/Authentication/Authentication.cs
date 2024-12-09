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
                throw new ArgumentNullException("Some obligatory objects are null");
                        
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case AuthenticationEvents.Request.LoginAdmin @e: HandleAuthenticationAdmin(@e); break;
            }
        }
        private void SetIpScore(IPScore? iPScore, AuthenticationEvents.Request.Context context)
        {
            if (iPScore == null)
            {
                IPScore = new IPScore(Apply);
                ApplyToEntity(IPScore, new AuthenticationEvents.Request.CreateIpScore(context.Ip));
            }
            else
                IPScore = iPScore;
        }
        private void HandleAuthenticationAdmin(AuthenticationEvents.Request.LoginAdmin e)
        {
            SetIpScore(e.IPScore , e.context);
            
            if ( e.auth.Any(x => e.client.Id == x.ClientId  ) )
            {
                Auth = e.auth.First(x=> x.ClientId == e.client.Id);               
                
            }

        }

        



    }
}
