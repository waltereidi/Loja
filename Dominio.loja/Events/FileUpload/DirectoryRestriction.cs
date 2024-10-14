using Dominio.loja.Interfaces.Files;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using Framework.loja.ExtensionMethods;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
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
            List<object> res = JsonSerializer.Deserialize<List<object>>(value ) ?? new();
            
            Pdf i = (Pdf)res.Find(x => x.PropertyValueExists(typeof(Type).Name, typeof(Pdf).Name));
           
                
            
        }

        public static implicit operator string(DirectoryRestriction dr)=> dr.Value;
      
    }
}
