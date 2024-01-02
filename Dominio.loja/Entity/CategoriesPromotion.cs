using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    [Table("categoriesPromotion")]
    public class CategoriesPromotion : MasterEntity
    {
        [Key]
        public int CategoriesPromotionId { get; set; }
        [ForeignKey("CateogoriesId")]
        public int CategoriesId { get; set; }
        public int DisplayOrder { get; set; }
        [NotMapped]
        public Categories Categories { get; set; }
    }
}
