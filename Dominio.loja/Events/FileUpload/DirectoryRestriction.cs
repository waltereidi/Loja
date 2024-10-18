using Dominio.loja.Interfaces.Files;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Nodes;
namespace Dominio.loja.Events.FileUpload
{
    public class DirectoryRestriction
    {
        private string Value 
        { 
            get => SerializeRestrictions(); 
            set => SetValue(this.Value); 
        }
        private void SetValue(string value)
        {
            this.Value= value;
        }
        private string SerializeRestrictions()
        {
            throw new NotImplementedException();
        }
        public List<IFileTypeRestriction> Restriction { get; set; } = new();
        
        public static implicit operator string(DirectoryRestriction dr) => dr.Value;
        public DirectoryRestriction() { }
        public DirectoryRestriction(string value)
        {
            var jsonArray = JsonObject.Parse(value).AsArray().Any() ?
                JsonObject.Parse(value).AsArray().ToList() 
                : null ;
            
            if (jsonArray == null)
                return;

            jsonArray.ForEach(f => {
                FileType ft = new(f.ToJsonString());
                ChooseFileTypeRestriction(ft);
            });
        }

        private void ChooseFileTypeRestriction(FileType ft)
        {
            switch (ft.Type)
            {
                case "Pdf": Restriction.Add(DeserializeFileTypeRestriction<Pdf>(ft)); break;
                case "Image": Restriction.Add(DeserializeFileTypeRestriction<Image>(ft)); break;
                case "Excel": Restriction.Add(DeserializeFileTypeRestriction<Excel>(ft)); break;
                case "Doc": Restriction.Add(DeserializeFileTypeRestriction<Doc>(ft)); break;
                case "Video": Restriction.Add(DeserializeFileTypeRestriction<Video>(ft)); break;
                case "ValidExtensions": Restriction.Add(DeserializeFileTypeRestriction<ValidExtensions>(ft)); break;
                case "All": Restriction.Add(DeserializeFileTypeRestriction<All>(ft)); break;
                default: throw new NotImplementedException();
            }
        }
        private T DeserializeFileTypeRestriction<T>(FileType ft) where T : FileType
        {
            T deserializedFileType = JsonSerializer.Deserialize<T>((string)ft);
            return deserializedFileType;
        }
    }
}
