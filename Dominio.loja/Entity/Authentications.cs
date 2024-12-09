using Framework.loja;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Dominio.loja.Entity
{
    public class Authentications : Entity<Guid>
    {
        [ForeignKey("IPScoreId")]
        public int IPScoreId { get; set; }
        [ForeignKey("ClientId")]
        public int ClientId { get; set; }
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
