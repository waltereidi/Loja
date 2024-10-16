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
        public List<IFileTypeRestriction> Restriction { get; set; }
        //public Restrictions? Restriction { get; private set; }
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
                
            });
                
            
        }

        private void ChooseFileTypeRestriction(string type)
        {
            switch (type)
            {
                case "Pdf": break;
                case "Image": break;


            }
        }


        private void AddRestrictionFromJsonObject(Task d)
        {

        }

        public static implicit operator string(DirectoryRestriction dr)=> dr.Value;
      
    }
}
