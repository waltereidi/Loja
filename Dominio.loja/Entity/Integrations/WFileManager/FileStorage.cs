using Dominio.loja.Events.Integracoes.WFileManager;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity.Integrations.WFileManager
{
    [Table("FileStorage")]
    public class FileStorage : MasterEntity<int>
    {
        [Key]
        public int FileStorageId { get; set; }
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
