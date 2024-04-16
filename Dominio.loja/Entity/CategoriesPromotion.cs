using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Dominio.loja.Entity
{
    [Table("categoriesPromotion")]
    public class CategoriesPromotion : MasterEntity<int>
    {
        [Key]
        public int CategoriesPromotionId { get; set; }
        [ForeignKey("CateogoriesId")]
        public int CategoriesId { get; set; }
        public int DisplayOrder { get; set; }
        
        public bool isActive { get; set; }
        public virtual Categories Categories { get; set; }
        public virtual ICollection<ProductsCategories> ProductsCategories { get; set; }
        

    }
}
