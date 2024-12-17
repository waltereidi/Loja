﻿using Dominio.loja.Events.Authentication;
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
                case AuthenticationEvents.Request.SetWrongPassword @e: DecreaseScore(e.value);break;
                case AuthenticationEvents.Request.SetClientNotFound @e: DecreaseScore(e.value);break;
                case AuthenticationEvents.Request.CreateIpScore @e:
                    {
                        IpAddress = e.ipAddress;
                        Score = 100;
                    }; break;
                case AuthenticationEvents.Request.BlockIp @e:
                    {
                        Score = 0;
                    };break;
                default: throw new InvalidOperationException(nameof(@event));
            }
        }
        private bool IsBeforeThirtyMinutes(DateTime value)
            => DateTime.Compare(value, DateTime.Now.AddMinutes(-30)) == 1 ? true : false;

        private void DecreaseScore(int value) 
        {
            if ((Updated_at == null && IsBeforeThirtyMinutes(Created_at)) || IsBeforeThirtyMinutes(Updated_at.Value))
                Score = Score < value ? 100-value : Score - value;
        }

    }
  

}
