using Framework.loja;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Dominio.loja.Entity.Integrations.WFileManager
{
    [Table("FileDirectory")]
    public class FileDirectory : Entity<int?>
    {
        [Required]
        public string DirectoryName { get; set; }
        [Required]
        public string Referer { get; set; }
        [Required]
        public string ValidExtensions { get; set; }
        public FileDirectory(Action<object> applier) : base(applier)
        {
        }
        public FileDirectory() { }

        //public static implicit operator string(FileDirectory fd)
        //{

        //    return fd.DirectoryName;
        //}
        protected override void When(object @event)
        {
            switch (@event)
            {

            }
        }

    }
}
