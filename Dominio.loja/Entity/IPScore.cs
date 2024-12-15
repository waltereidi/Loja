using Dominio.loja.Events.Authentication;
using Framework.loja;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;


namespace Dominio.loja.Entity
{
    /// <summary>
    /// Id refers to remote IP address
    /// </summary>

    [Index(nameof(IpAddress), IsUnique = true)]
    public class IPScore : Entity<int?>
    {
        [Required]
        public int Score { get; set; }
        [Required]
        public IPAddress? IpAddress { get; set; }
        
        public IPScore()
        {

        }
        public IPScore( Action<object> @event ) : base( @event ) 
        {
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case AuthenticationEvents.Request.CreateIpScore @e:
                    {
                        IpAddress = e.ipAddress;
                        Score = 100;
                        Created_at = DateTime.Now;
                    }break;

                default: throw new InvalidOperationException(nameof(@event));
            }
        }
    }
}
