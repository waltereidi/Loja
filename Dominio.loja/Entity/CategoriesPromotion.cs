using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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

        public virtual Categories Categories { get; set; }
    }
}
