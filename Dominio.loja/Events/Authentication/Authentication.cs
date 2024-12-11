using Dominio.loja.Entity;
using Framework.loja;
using System.Security.Authentication;

namespace Dominio.loja.Events.Authentication
{
    public class Authentication : AggregateRoot<Guid>
    {
        
        public Clients Client { get; set; }
        public IPScore IPScore { get; set; }
        public Authentications Auth { get; set; }
        private string Referer { get; set; }

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

            if( IPScore.Score <= 0 )
                throw new AuthenticationException(nameof(IPScore.Score));

            
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case AuthenticationEvents.Request.LoginAdmin @e: HandleAuthentication(@e); break;
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
        private void SetUp(AuthenticationEvents.Request.LoginAdmin e)
        {

            SetIpScore(e.IPScore, e.context);
            Referer = e.context.Referer;
            SetAuthentications(e);

        }

        private void SetAuthentications(AuthenticationEvents.Request.LoginAdmin e)
        {
            if (e.auth.Any(x => e.client.Id == x.ClientId && x.IPScore.Id == x.IPScoreId ))
            {
                
            }
        }


        private void HandleAuthentication(AuthenticationEvents.Request.LoginAdmin e)
        {
            SetUp(e);




        }

        



    }
}
