using Framwork.loja.Utility.Files;
using System.Text.Json;
using static Dominio.loja.Events.FileUpload.FileType;

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

    }
}
