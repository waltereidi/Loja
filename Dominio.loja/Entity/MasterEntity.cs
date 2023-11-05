using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    public class MasterEntity
    {
        [Key]
        public int? Id { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get;set; }

    }
}
