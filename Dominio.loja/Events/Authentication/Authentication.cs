using Dominio.loja.Entity;
using Dominio.loja.Interfaces;
using Framework.loja;
using System.Security.Authentication;
using static Dominio.loja.Events.Authentication.AuthenticationEvents;

namespace Dominio.loja.Events.Authentication
{
    public class Authentication : AggregateRoot<IAuthentication> 
    {
        
        public Clients _Client { get;private set; }
        public IPScore _IPScore { get; private set; }
        public Authentications _Auth { get; private set; }
        
        
        private string Referer { get; set; }

        public Authentication(IAuthentication auth)
        {
            base.Id = auth ?? throw new ArgumentNullException();
        }
        /// <summary>
        /// Defines ipScore, if not existent creates a new
        /// </summary>
        public void SetIpScore(Request.CreateIpScore @e) => Apply(@e);
        /// <summary>
        /// Initializes all obligatory objects from this domain
        /// </summary>
        /// <param name="e"></param>
        public void SetClient(Request.SetClient @e) => Apply(@e);
        /// <summary>
        /// Set authentication from all authentications of this IP
        /// </summary>
        /// <param name="e"></param>
        public void SetAuthentications(Request.SetAuthentications @e) => Apply(@e);
        

        protected override void EnsureValidState()
        {
            if (_IPScore == null )
                throw new ArgumentNullException("Authentication source does not have IP");

            if(_IPScore.Score <= 0 )
                throw new AuthenticationException(nameof(_IPScore.Score));

            base.Id.ValidateAuthentication(this);

        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Request.SetAuthentications @e:
                    {
                        if (@e.auth.Any(x => x.ClientId == _Client.Id && x.IPScoreId == _IPScore.Id))
                        {
                            _Auth = e.auth.First(x => x.ClientId == _Client.Id && x.IPScoreId == _IPScore.Id);
                        }
                        else
                        {
                            _Auth = new Authentications(Apply);
                            ApplyToEntity(_Auth , new Request.CreateAuthentications( _IPScore, _Client ));
                        }
                    };break;
                case Request.CreateIpScore @e: 
                    {
                        if (e.iPScore == null)
                        {
                            _IPScore = new IPScore(Apply);
                            ApplyToEntity(_IPScore, e);
                        }
                        else
                            _IPScore = e.iPScore;
                        
                    };break;
                case Request.SetClient @e:
                    {
                        _Client = e.client;

                    }; break;
            }
        }
        
        
        
    }
}
