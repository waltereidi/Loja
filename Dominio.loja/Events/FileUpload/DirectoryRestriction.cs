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
                Restriction.Add(ChooseFileTypeRestriction(ft));
            });
        }
        public void ValidateRestrictions(FileType ft , FileInfo fi)
        {
            List<IFileTypeRestriction> validations = Restriction.FindAll(x=> x.Type == ft.Type 
                || x.Type == typeof(All).Name 
                || x.Type == typeof(ValidExtensions).Name );
            
            validations.ForEach(f => f.IsValid(ft , fi));
        }

        private IFileTypeRestriction ChooseFileTypeRestriction(FileType ft)
        {
            switch (ft.Type)
            {
                case "Pdf": return DeserializeFileTypeRestriction<Pdf>(ft);
                case "Image": return DeserializeFileTypeRestriction<Image>(ft);
                case "Excel": return DeserializeFileTypeRestriction<Excel>(ft);
                case "Doc": return DeserializeFileTypeRestriction<Doc>(ft);
                case "Video": return DeserializeFileTypeRestriction<Video>(ft);
                case "ValidExtensions":return  DeserializeFileTypeRestriction<ValidExtensions>(ft);
                case "All": return DeserializeFileTypeRestriction<All>(ft);
                default: throw new NotImplementedException();
            }
        }

        T DeserializeFileTypeRestriction<T>(FileType ft) where T : FileType
            => JsonSerializer.Deserialize<T>((string)ft);
    }
}
