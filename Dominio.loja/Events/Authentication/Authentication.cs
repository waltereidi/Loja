using Dominio.loja.Entity;
using Framework.loja;
using System.Linq;
using System.Reflection;
using System.Security.Authentication;
using static Dominio.loja.Events.Authentication.AuthenticationEvents;
using static Dominio.loja.Events.Authentication.AuthenticationEvents.Request;

namespace Dominio.loja.Events.Authentication
{
    public class Authentication : AggregateRoot<SuccessfullAuthentication>
    {
        
        public Clients Client { get;private set; }
        public IPScore IPScore { get; private set; }
        public Authentications Auth { get; private set; }
        
        
        private string Referer { get; set; }

        public Authentication()
        {
            base.Id = new SuccessfullAuthentication();
        }
        /// <summary>
        /// Defines ipScore , if not existent creates a new
        /// </summary>
        public void SetIpScore(AuthenticationEvents.Request.CreateIpScore @e) => Apply(@e);
        /// <summary>
        /// Initializes all obligatory objects from this domain
        /// </summary>
        /// <param name="e"></param>
        public void SetClient(AuthenticationEvents.Request.SetClient @e) => Apply(@e);
        public void SetAuthentications(AuthenticationEvents.Request.SetAuthentications @e) => Apply(@e);
        public void SetContext(Context @e) => Apply(@e);

        protected override void EnsureValidState()
        {
            if (Client == null || IPScore == null || Auth != null)
                throw new ArgumentNullException("Some obligatory objects are null");

            if( IPScore.Score <= 0 )
                throw new AuthenticationException(nameof(IPScore.Score));

            if( !Client.PermissionsGroup.PermissionsRelations.Any(x=>x.Permissions.Name == Referer))
                throw new AuthenticationException("Client does not have permission to authenticate");
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case AuthenticationEvents.Request.SetAuthentications @e:
                    {

                    };break;
                case AuthenticationEvents.Request.CreateIpScore @e: 
                    {
                        if (e.iPScore == null)
                        {
                            IPScore = new IPScore(Apply);
                            ApplyToEntity(IPScore, e);
                        }
                        else
                            IPScore = e.iPScore;
                        
                    };break;
            }
        }
        
        
        
        /// <summary>
        /// Define authentications , if not exists create a new
        /// </summary>
        /// <param name="e"></param>
        /// <exception cref="ArgumentNullException"></exception>
        private void SetAuthentications(AuthenticationEvents.Request.LoginAdmin e)
        {
            if (e.auth.Any(x => e.client.Id == x.ClientId && x.IPScore.Id == x.IPScoreId ))
            {
                Auth = e.auth.First(x => e.client.Id == x.ClientId && x.IPScore.Id == x.IPScoreId);
            }
            else
            {
                Auth = new Authentications(Apply);
                ApplyToEntity(Auth, 
                    new AuthenticationEvents.Request.CreateAuthentications(
                        e.client.Id ?? throw new ArgumentNullException(nameof(e.client.Id)), 
                        IPScore.Id ?? throw new ArgumentNullException(nameof(IPScore.Id)) 
                    ));
            }
        }


        private void HandleAuthentication(AuthenticationEvents.Request.LoginAdmin e)
        {
            SetUp(e);
            IPScoreCalculation();
        }
        /// <summary>
        /// Set a new value for IPScore based on authentication
        /// </summary>
        private void IPScoreCalculation()
        {
            
        }
    }
}
