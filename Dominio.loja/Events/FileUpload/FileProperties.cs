using System.Text.Json;

namespace Dominio.loja.Events.FileUpload
{
    public class FileProperties
    {
        private string Value { get; set; }
        private Properties Property{ get; set; }
        private record Properties();
        public FileProperties() { }

        public FileProperties(string value)
        {
            Property = JsonSerializer.Deserialize<Properties>(value) ?? throw new ArgumentNullException();
            Value = value;
        }



        public static implicit operator string(FileProperties fp)
        {
            return fp.Value;
        }
    }
}
