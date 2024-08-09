using Dominio.loja.Events.FileUpload;
using Framework.loja;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Enumeration;

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
        public string FileName { get; set; }
        public string OriginalName { get; set; }
        public virtual FileDirectory Directory {get;set;}
        public FileStorage()
        {

        }
        public FileStorage(Action<object> applier) : base(applier)
        {
        }
        protected override void When(object @event)
        {
            switch (@event)
            {
                case FileManagerEvents.CreateFile e:
                        FileDirectoryId = e.fd.Id ?? throw new ArgumentNullException(nameof(e.fd));
                        Directory = e.fd;
                        Created_at = DateTime.Now;
                        CreationTime = e.fi.file.CreationTime;
                        CreationTimeUtc = e.fi.file.CreationTimeUtc;
                        Length = e.fi.file.Length;
                        Extension = e.fi.file.Extension;
                        FileName = e.fi.file.Name;
                        OriginalName = e.fi.fileName;
                    ; break;
                default: throw new InvalidOperationException();
            }
        }

    }
}
