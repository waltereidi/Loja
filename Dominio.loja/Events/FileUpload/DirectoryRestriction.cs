using Dominio.loja.Interfaces.Files;
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
                case "Pdf": Restriction.Add(new Pdf(ft)); break;
                case "Image": Restriction.Add(new Image(ft)); break;
                case "Excel": Restriction.Add(new Excel(ft)); break;
                case "Doc": Restriction.Add(new Doc(ft)); break;
                case "Video": Restriction.Add(new Video(ft)); break;
                case "ValidExtensions": Restriction.Add(new ValidExtensions(ft)); break;
                case "All": Restriction.Add(new All(ft)); break;
                default: throw new NotImplementedException();
            }
        }

    }
}
