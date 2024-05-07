using Dominio.loja.Events.Integracoes.WFileManager;
using Framework.loja;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.loja.Entity.Integrations.WFileManager
{
    [Table("FileDirectory")]
    public class FileDirectory : Entity<int?>
    {
        public static explicit operator FileDirectory(string dir) => new (dir);
        public static explicit operator FileDirectory(int id) => new (id);
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
            Id = id;
        }

        public static implicit operator string(FileDirectory fd)
        {

            return fd.DirectoryName;
        }
        protected override void When(object @event)
        {
            var i = @event;
        }

    }
}
