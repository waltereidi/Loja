using Dominio.loja.Events.Authentication;
using Framework.loja;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Dominio.loja.Entity
{
    /// <summary>
    /// TODO : Improve design for hardcoded values such as time delay for point changes<br></br>
    /// </summary>
    [Index(nameof(ClientId), IsUnique = true)]
    public class Authentications : Entity<Guid>
    {
        [ForeignKey("IPScoreId")]
        public Guid IPScoreId { get; set; }

        [ForeignKey("ClientId")]

        public int ClientId { get; set; }
        /// <summary>
        /// Refers to situation where the client may get blocked 
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// Refers to last authentication attempt is successfull or not 
        /// </summary>
        public bool Success {get;set;}
        /// <summary>
        /// Refers human readable description from last authentication
        /// </summary>
        [AllowNull]
        public string? Description { get; set; }

        public virtual Clients Client { get; set; }
        public virtual IPScore IPScore { get; set; }
        
        public Authentications() { }
        public Authentications(Action<object> @event) : base(@event)
        {

        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case AuthenticationEvents.Request.SetWrongPassword @e:
                    {
                        DecreaseScore(e.value ?? throw new ArgumentNullException("Score amount not set"));
                        Description =Score == 0 ? "User got blocked due to many wrong password authentications attempt" : "Wrong password login attempt." ;
                        Success = false;


                    }; break;
                case AuthenticationEvents.CreateAuthentications @e:
                    {
                        ClientId = e.client.Id.Value;
                        Success = false; 
                        Score = 100;
                        IPScoreId = e.ipScore.Id;
                        Id = Guid.NewGuid();
                    }; break;
                case AuthenticationEvents.SetSuccessfullAuthentication @e:
                    {
                        Success = true;
                        Score = 100;
                        IPScoreId = e.ipScoreId ?? throw new ArgumentNullException(nameof(e.ipScoreId));
                        Description = "Successfull client authentication.";
                    }; break;
                default: throw new InvalidOperationException(nameof(@event));
            }

        }

        private bool IsBeforeThirtyMinutes(DateTime value)
            => DateTime.Compare(value, DateTime.Now.AddMinutes(-30)) == 1 ? true : false;

        private void DecreaseScore(int value)
        {
            if ((Updated_at == null && IsBeforeThirtyMinutes(Created_at)) || IsBeforeThirtyMinutes(Updated_at.Value))
                Score = Score < value ? 100 - value : Score - value;

        }
    }
}
