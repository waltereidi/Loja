using Dominio.loja.Entity;
using Framework.loja;
using System.Security.Authentication;
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

        protected override void EnsureValidState()
        {

            if (_IPScore?.Score <= 0)
                throw new AuthenticationException(nameof(_IPScore.Score));



        }
        /// <summary>
        /// From martin fowler, too many conditionals should be handled with polymorphism
        /// </summary>
        public virtual bool AuthenticationAuthentication()
        {
            if (_Client == null)
                return false;

            if (_Auth == null)
                return false;

            return true;
        }
        protected override void When(object @event)
        {
            //Event insertion order IpScore ,Clients ,  SetAuthentication 
            switch (@event)
            {
                case Request.SetAuthentications @e:
                    {
                        SetAuthentication(e);
                        CalculateIpScore(e);
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
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void CalculateIpScore(Request.SetAuthentications @e)
        {

        }
    }
}
