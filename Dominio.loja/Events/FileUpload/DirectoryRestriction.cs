using Dominio.loja.Enums;
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

        public static implicit operator string(DirectoryRestriction dr)
        {
            return dr.Value;
        }
        public void ValidateExtension(string extension)
        {
            Restriction.extensions.Validate(extension);
            
            ValidateExtensionProperties(extension);
        }

        public FileExtensions ValidateExtensionProperties(string extension) => extension.ToLower() switch
        {
            string a when a.Contains("pdf") => FileExtensions.Pdf,
            string b when new[] { "xls", "xlsx" }.Any(x => x.Contains(b)) => FileExtensions.Excel,
            string c when new[] { "doc", "docx" }.Any(x => x.Contains(c)) => FileExtensions.Doc,
            string d when new[] { "png", "jpg", "jpeg", "bmp", "webp" }.Any(x => x.Contains(d)) => FileExtensions.Excel,
            _ => FileExtensions.Unmaped
        };
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
