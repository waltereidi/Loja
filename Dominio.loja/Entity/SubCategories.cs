using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    [Table("SubCategories")]
    public class SubCategories
    {
        [Key]
        public int ID_SubCategories {get;set;}
        [StringLength(30)]
        public string Name { get;set;}
        public int ID_Categories { get;set;}
        
    }
}
