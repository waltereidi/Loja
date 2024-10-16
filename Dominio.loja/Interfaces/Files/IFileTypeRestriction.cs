using System.Text.Json.Serialization;

namespace Dominio.loja.Interfaces.Files
{
    public interface IFileTypeRestriction
    {
        public void IsValid(object ft);
        public string Type { get; set; }
        public void SerializeFileProperties();
        public void DeserializeFileProperties();
    }
}
