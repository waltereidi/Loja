using Dominio.loja.Events.Integracoes.WFileManager;
using Dominio.loja.Events.Praedicamenta;
using Framework.loja;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Dominio.loja.Entity.Integrations.WFileManager
{
    [Table("FileDirectory")]
    public class FileDirectory : Entity<int?>
    {
        public static explicit operator FileDirectory(string dir) => new (dir);
        public static explicit operator FileDirectory(int id) => new (id);
        [Required]
        public string DirectoryName { get; set; }
        [Required]
        public string Referer { get; set; }
        [Required]
        public string ValidExtensions { get; set; }
        public FileDirectory(Action<object> applier) : base(applier)
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

        //public static implicit operator string(FileDirectory fd)
        //{

        //    return fd.DirectoryName;
        //}
        protected override void When(object @event)
        {
            switch (@event)
            {
                case FileManagerEvents.FileUploaded e:
                    break;
                case PraedicamentaEvents.UpdateCategory e:
                    Updated_at = DateTime.Now;
                    break;
                default: throw new NotImplementedException();
            }
        }

    }
}
