using Framework.loja;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    public class IPScore : Entity<int?>
    {
        [Required]
        public IPAddress IPAddress { get; set; }
        [Required]
        public int Score { get; set; }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}
