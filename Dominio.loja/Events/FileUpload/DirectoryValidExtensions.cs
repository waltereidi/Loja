
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;

namespace Dominio.loja.Events.FileUpload
{
    public class DirectoryValidExtensions
    {
        private string Value { get; set; }
        [JsonIgnore]
        private string[] Extensions { get; set; }
        public DirectoryValidExtensions() { }
        public DirectoryValidExtensions(string value)
        {
            Extensions = !value.IsNullOrEmpty() ? value.Split(';'): [];
            Value = value;
        }

        public static implicit operator string(DirectoryValidExtensions dve)
        {
            return dve.Value;
        }
        public void Validate(string extension)
        {
            if (Extensions.Count() > 0 && Extensions.Any(x => extension.Contains(x)))
                throw new InvalidDataException("File extensions does not match");
        }

        


}
}
