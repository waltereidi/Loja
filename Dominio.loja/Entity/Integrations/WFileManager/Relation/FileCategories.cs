
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.loja.Entity.Integrations.WFileManager.Relation
{
    [Table("FileCategories")]
    public class FileCategories : FileRelation
    {
        public int CategoryId { get; set; }
        public FileCategories() { }
        public FileCategories(int fileStorageId, int categoryId) : base(fileStorageId)
        {
        }
    }
}
