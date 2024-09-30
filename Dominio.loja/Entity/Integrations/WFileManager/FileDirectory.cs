using Dominio.loja.Events.FileUpload;
using Framework.loja;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.loja.Entity.Integrations.WFileManager
{
    [Table("FileDirectory")]
    public class FileDirectory : Entity<int?>
    {
        [Required]
        public string DirectoryName { get; set; }
        /// <summary>
        /// Upload EndPoint Reference 
        /// </summary>
        [Required]
        public string Referer { get; set; }

        [Required]
        public virtual DirectoryRestriction Restriction { get; set; }

        public FileDirectory(Action<object> applier) : base(applier)
        {

        }
        public FileDirectory() { }

        public bool IsValidExtension()
        {

        }
        protected override void When(object @event)
        {
     
        }

    }
}
