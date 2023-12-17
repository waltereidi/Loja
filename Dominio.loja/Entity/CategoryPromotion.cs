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
        public int CategoriesPromotion { get; set; }

        [ForeignKey(nameof(ID_Cateogories))]
        public int ID_Cateogories { get; set; }
        public Categories Category { get; set; }
        public int DisplayOrder { get; set; }
    }
}
