
using System.Text.Json;
using System.Text.Json.Serialization;
using static Dominio.loja.Events.FileUpload.DirectoryRestriction;

namespace Dominio.loja.Events.FileUpload
{
    public class FileType 
    {
        [JsonIgnore]
        public string Value { get;  set; }
        public virtual string Type { get; set; }    
        public FileType() {}

        public FileType(string value)
        {
            Value = value;
            var json = JsonSerializer.Deserialize<FileType>(value);
            Type = json.Type;
        }
        public static implicit operator string(FileType ft) => ft.Value;
        public virtual void SerializeFileProperties()
        {
            Value = JsonSerializer.Serialize(this);
        }
    }




}
