using Framwork.loja.Utility.Files;
using System.Text.Json;
using static Dominio.loja.Events.FileUpload.FileManagerEvents.FileProperties;

namespace Dominio.loja.Events.FileUpload
{
    public class DirectoryRestriction
    {
        private string Value { get; set; }
        public Restrictions Restriction { get; private set; }
        public record Restrictions(Image? image , Video? video , Pdf? pdf, Doc? doc, Excel? excel , All? all ,DirectoryValidExtensions? extensions);
        public DirectoryRestriction() { }
        
        public DirectoryRestriction(string value)
        {
            Restriction = JsonSerializer.Deserialize<Restrictions>(value) ?? throw new ArgumentNullException();

            Value = value;
        }

        public static implicit operator string(DirectoryRestriction dr)=> dr.Value;

        public void ValidateExtension(string extension) => Restriction.extensions?.Validate(extension);

        /// <summary>
        /// Non existent validations should be allowed to pass
        /// </summary>
        /// <param name="properties"></param>
        public void ValidateExtensionProperties(object properties) 
        {
            switch (properties)
            {
                case Pdf cmd: Restriction.pdf?.IsValid(cmd);break;
                case Excel cmd: Restriction.excel?.IsValid(cmd); break;
                case Doc cmd: Restriction.doc?.IsValid(cmd); break;
                case Image cmd: Restriction.image?.IsValid(cmd); break;
                case Video cmd: Restriction.video?.IsValid(cmd); break;
            }
        }
        
        private void ValidateRestrictionsTypeAll(int length)
        {
            var all = Restriction.all;

            if (all.min > 0 && all.min < length)
            {
                throw new InvalidDataException($"File length smaller than {(string)new ReadableFileLength(length)}");
            }

            {
                throw new InvalidDataException($"File length bigger than {(string)new ReadableFileLength(length)}");
            }
        }
    }
}
