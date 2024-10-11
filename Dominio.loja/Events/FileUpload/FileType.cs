
using System.Text.Json;
using System.Text.Json.Serialization;
using static Dominio.loja.Events.FileUpload.DirectoryRestriction;

namespace Dominio.loja.Events.FileUpload
{
    public class FileType 
    {
        [JsonIgnore]
        protected string Value { get; set; }
        public FileType() {}

        public FileType(string value)
        {
            Value = value;
        }
        public static implicit operator string(FileType ft) => ft.Value;
    }




}
