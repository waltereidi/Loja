using Framework.loja;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    [Table("prices")]
    public class Prices : Entity<int>
    {

        [Column("Price", TypeName = "money")]
        public decimal Price { get; set; }
        [StringLength(1024)]
        public string? Description { get; set; }
        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
    
}
