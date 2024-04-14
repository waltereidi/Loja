using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.loja.Entity.Integrations.WFileManager
{
    [Table("FileDirectory")]
    public class FileDirectory
    {
        [Key]
        public int FileDirectoryId { get; set; }
        [Required]
        public string DirectoryName { get; set; }

        public FileDirectory()
        {

        }
        public FileDirectory(string directory )
        {
            DirectoryName = directory;
               
        }
        public FileDirectory(int id)
        {
            FileDirectoryId = id;
        }

        public static implicit operator string(FileDirectory fd)
        {

            return fd.DirectoryName;
        }
        public static explicit operator FileDirectory(string dir) => new FileDirectory(dir);
        public static explicit operator FileDirectory(int id) => new FileDirectory(id);
    }
}
