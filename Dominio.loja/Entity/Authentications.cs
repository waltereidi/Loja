using Framework.loja;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Dominio.loja.Entity
{
    public class Authentications : Entity<int>
    {
        [ForeignKey("IPScoreId")]
        public int IPScoreId { get; set; }

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
        public string Description { get; set; }


        public virtual Clients Client { get; set; }
        public virtual IPScore IPScore { get; set; }
        
        public Authentications() { }
        public Authentications(Action<object> @event) : base(@event)
        {

        }

        protected override void When(object @event)
        {

            throw new NotImplementedException();
        }
    }
}
