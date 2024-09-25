using Framework.loja;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.loja.Entity.Integrations.WFileManager
{
    [NotMapped]
    public class FileRelation : Entity<Guid> 
    {
        public int FileStorageId { get; set; }
        public virtual FileStorage FileStorage { get; set; }
        public FileRelation() { }
        public FileRelation( int fileStorageId) 
        {
            FileStorageId = fileStorageId;
        }
        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }

}
