using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    [Table("categoryPromotion")]
    public class CategoryPromotion : MasterEntity
    {
        [Key]
        public int ID_CategoriesPromotion { get; set; }
        [ForeignKey("ID_Cateogories")]
        public int ID_Cateogories { get; set; }
        public int DisplayOrder { get; set; }
        [NotMapped]
        public Categories Category { get; set; }
    }
}
