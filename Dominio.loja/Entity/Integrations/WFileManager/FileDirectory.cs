using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity.Integrations.WFileManager
{
    [Table("FileDirectory")]
    public class FileDirectory
    {
        [Key]
        public int FileDirectoryId { get; set; }
        [Required]
        public string DirectoryName { get; set; }
    }
}
