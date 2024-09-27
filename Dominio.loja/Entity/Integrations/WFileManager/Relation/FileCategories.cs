
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.loja.Entity.Integrations.WFileManager.Relation
{
    [Table("FileCategories")]
    public class FileCategories : FileRelation
    {
        [ForeignKey("CategoryId")]
        public int CategoriesId { get; set; }
        public virtual Categories Category { get; set; }
        public FileCategories() { }

        public FileCategories(FileStorage file, int categoryId ) : base(file)
        {
            CategoriesId = categoryId;
        }
    }
}
