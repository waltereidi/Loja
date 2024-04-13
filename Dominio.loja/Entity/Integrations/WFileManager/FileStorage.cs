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
    public class FileStorage
    {
        [Key]
        public int FileStorageId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime CreationTimeUtc { get; set; }
        public long Length { get; set; }
        public string Extension { get; set; }
        public FileDirectory Directory {get;set;}

        public FileStorage(FileInfo fi)
        {
            CreationTime=fi.CreationTime;
            CreationTimeUtc=fi.CreationTimeUtc;
            Extension = fi.Extension;
        }
    }
}
