using Dominio.loja.Interfaces.Files;
using Framwork.loja.Utility.Files;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using static Dominio.loja.Events.FileUpload.FileManagerEvents.FileProperties;
using ExtensionMethods;
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
            List<object> res = JsonSerializer.Deserialize<List<object>>(value) ?? new();
            
                
        }

        public static void GobbleGobble(this string s)
        {
            Console.Out.WriteLine("Gobble Gobble, " + s);
        }

        public static implicit operator string(DirectoryRestriction dr)=> dr.Value;
      
    }
}
