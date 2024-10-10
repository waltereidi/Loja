using Dominio.loja.Events.FileUpload;
using Framework.loja;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.loja.Entity.Integrations.WFileManager
{
    [NotMapped]
    public abstract class FileRelation : Entity<int?> 
    {
        [ForeignKey("FileStorageId")]
        public Guid FileStorageId { get; set; }
        public virtual FileStorage FileStorage { get; set; }
        public FileRelation() { }

        public FileRelation(FileStorage file)
        {
            FileStorage = file;
            FileStorageId = file.Id;
            Created_at = DateTime.Now;
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }

}
