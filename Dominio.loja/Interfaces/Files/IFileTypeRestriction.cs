using Dominio.loja.Events.FileUpload;
using System.Text.Json.Serialization;
using static Dominio.loja.Events.FileUpload.FileManagerEvents;

namespace Dominio.loja.Interfaces.Files
{
    public interface IFileTypeRestriction
    {
        public void IsValid(object ft, FileInfo fi);
        public string Type { get; set; }
        public void SerializeFileProperties();
        //public void DeserializeFileProperties();
    }
}
