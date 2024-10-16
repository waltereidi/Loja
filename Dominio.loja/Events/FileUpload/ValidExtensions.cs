
using Dominio.loja.Interfaces.Files;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;

namespace Dominio.loja.Events.FileUpload
{
    public class ValidExtensions : FileType , IFileTypeRestriction
    {
        private List<string> Extensions { get; set; } = new();
        private string Extension { get; set; }
        public ValidExtensions() { }
        public ValidExtensions(string value)
        {
            
            Value = value;
        }

        public void IsValid(object ft)
        {
            ValidExtensions ve = (ValidExtensions)ft;

            if (Extensions.Count() > 0 && Extensions.Any(x => Extension.Contains(x)))
                throw new InvalidDataException("File extensions does not match");
        }

        public void SerializeFileProperties()
        {
            throw new NotImplementedException();
        }

        public void DeserializeFileProperties()
        {
            throw new NotImplementedException();
        }
    }
}
