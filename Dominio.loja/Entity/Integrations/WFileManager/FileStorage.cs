using Dominio.loja.Events.FileUpload;
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
        public string FileName { get; set; }
        public string OriginalName { get; set; }
        /// <summary>
        /// FileProperties is used from inherited classes
        /// </summary>
        public string FileProperties { get; set; }
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
                        FileDirectoryId = e.Fd.Id ?? throw new ArgumentNullException(nameof(e.Fd));
                        Directory = e.Fd;
                        Created_at = DateTime.Now;
                        CreationTime = e.Fi.CreationTime;
                        CreationTimeUtc = e.Fi.CreationTimeUtc;
                        Length = e.Fi.Length;
                        Extension = e.Fi.Extension;
                        FileName = e.Fi.Name;
                        OriginalName = e.OriginalName;
                     break;

                default: throw new InvalidOperationException();
            }
        }
        
    }
}
