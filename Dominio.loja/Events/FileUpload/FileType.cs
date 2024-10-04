
using System.Text.Json;
using static Dominio.loja.Events.FileUpload.DirectoryRestriction;

namespace Dominio.loja.Events.FileUpload
{
    public class FileType
    {
        private string Value { get; set; }
        public FileType() {}
        public virtual void IsValid(object ft) => throw new NotImplementedException();
        public virtual string GetSerializedOptions()
        {
            return JsonSerializer.Serialize(this);
        }
        public FileType(string value)
        {
            Value = value;
        }

        public static implicit operator string(FileType ft) => ft.Value;
    }




}
