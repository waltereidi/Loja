using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    [Table("categories")]
    public abstract class Categories : MasterEntity<int>
    {

        [StringLength(120)]
        public string Name { get; set; }
        [StringLength(2048)]
        public string? Description { get; set; }
        public virtual ICollection<SubCategories> SubCategories { get; set; }
    }


}
