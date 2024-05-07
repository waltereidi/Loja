using Dominio.loja.Events.Integracoes.WFileManager;
using Framework.loja;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.loja.Entity.Integrations.WFileManager
{
    [Table("FileStorage")]
    public class FileStorage : Entity<int?>
    {
        public DateTime CreationTime { get; set; }
        public DateTime CreationTimeUtc { get; set; }
        public long Length { get; set; }
        public string Extension { get; set; }
        [ForeignKey("FileDirectoryId")]
        public int FileDirectoryId { get; set; }
        public virtual FileDirectory Directory {get;set;}
        public FileStorage()
        {

        }
        public FileStorage(FileInfo fi)
        {
            CreationTime=fi.CreationTime;
            CreationTimeUtc=fi.CreationTimeUtc;
            Extension = fi.Extension;
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case FileManagerEvents.FileUploaded e:; break;

            }
        }

    }
}
