using Framework.loja;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.loja.Entity
{
    public class Authentication : Entity<Guid>
    {
        [ForeignKey("IPScoreId")]
        public int IPScoreId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual Clients Client { get; set; }



        public int ClientId { get; set; }
                
        public Authentication() { }
        public Authentication(Action<object> @event) : base(@event)
        {

        }

        protected override void When(object @event)
        {

            throw new NotImplementedException();
        }
    }
}
