using Dominio.loja.Entity;
using Framework.loja;
using static Dominio.loja.Events.Authentication.AuthenticationEvents;

namespace Dominio.loja.Events.Authentication
{

    public class Authentication : AggregateRoot<int>
    {

        public Clients _Client { get; private set; }
        public IPScore _IPScore { get; private set; }
        public Authentications _Auth { get; private set; }


        private string Referer { get; set; }

        public Authentication()
        {
        }
        /// <summary>
        /// Defines ipScore, if not existent creates a new
        /// </summary>
        public void SetIpScore(Request.CreateIpScore @e) => Apply(e);
        /// <summary>
        /// Initializes all obligatory objects from this domain
        /// </summary>
        /// <param name="e"></param>
        public void SetClient(Clients @e) => Apply(e);
        /// <summary>
        /// Set authentication from all authentications of this IP
        /// </summary>
        /// <param name="e"></param>
        public void SetAuthentications(IEnumerable<Authentications> @e) => Apply(e);
        /// <summary>
        /// Set wrong password authentication attempt
        /// </summary>
        /// <param name="e"></param>
        public void SetWrongPassWord(Request.SetWrongPassword @e) => Apply(e);
        /// <summary>
        /// Set client not found authentication attempt
        /// </summary>
        /// <param name="e"></param>
        public void SetClientNotFound(Request.SetClientNotFound @e) => Apply(e);

        protected override void EnsureValidState()
        {

            ValidateAuthentication();
        }
        /// <summary>
        /// From martin fowler, too many conditionals should be handled with polymorphism
        /// </summary>
        public virtual void ValidateAuthentication()
        {
            if (_IPScore?.Score <= 0 && _Auth != null)
                _Auth.Success = false;

            if (_Auth != null && _Auth.Score == 0)
                ApplyToEntity(_Auth, new Request.AppendAuthMessage("User is blocked", false));
        }
        protected override void When(object @event)
        {
            //Event insertion order IpScore ,Clients ,  SetAuthentication 
            switch (@event)
            {
                case Request.SetClientNotFound @e:
                    {
                        ApplyToEntity(_IPScore, @e);

                    };break;
                case Request.SetWrongPassword @e:
                    {
                        ApplyToEntity(_Auth, e);
                        ApplyToEntity(_IPScore, e);
                    };break;
                case Request.SetAuthentications @e:
                    {
                        SetAuthentication(e);
                        OutOfCommercialTimeMultiAccount(e);
                    }
                    break;
                case Request.CreateIpScore @e:
                    {
                        if (@e.ipScore == null)
                        {
                            _IPScore = new IPScore(Apply);
                            ApplyToEntity(_IPScore, @e);
                        }
                        else
                            _IPScore = @e.ipScore;

                    }; break;
                case Clients @e: _Client = e; break;

            }
        }
        /// <summary>
        /// Do this event after set IpScore and Client
        /// </summary>
        /// <param name="e"></param>
        protected virtual void SetAuthentication(Request.SetAuthentications @e)
        {
            if (e.auth.Any(x => x.ClientId == _Client.Id && x.IPScoreId == _IPScore.Id))
            {
                _Auth = e.auth.First(x => x.ClientId == _Client.Id );
            }
            else
            {
                _Auth = new Authentications(Apply);
                ApplyToEntity(_Auth, new Request.CreateAuthentications(_IPScore, _Client));

            }
        }
        /// <summary>
        /// Maximum of 3 logins from same IP out of commercial time
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OutOfCommercialTimeMultiAccount(Request.SetAuthentications @e)
        {
            int nonCommercialTimeLogin = e.auth.Select(x => new 
            {
                Hour = x.Updated_at != null ? x.Updated_at.Value.Hour : x.Created_at.Hour ,
                DayOfWeek = x.Updated_at != null ? x.Updated_at.Value.DayOfWeek : x.Created_at.DayOfWeek ,
            }).Count(x=>  
                x.DayOfWeek == DayOfWeek.Sunday 
                || x.DayOfWeek == DayOfWeek.Saturday 
                || (x.Hour <= 7 && x.Hour >= 19 )
            );
            
            if (nonCommercialTimeLogin > 3)
            {
                ApplyToEntity(_IPScore , new Request.SetOutOfCommercialTimeMultipleAccountAttempt());
            }

        }

    }
    
}
