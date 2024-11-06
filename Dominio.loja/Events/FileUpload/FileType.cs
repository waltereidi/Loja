
using Dominio.loja.Interfaces.Files;
using System.Text.Json;
using System.Text.Json.Serialization;
using static Dominio.loja.Events.FileUpload.DirectoryRestriction;

namespace Dominio.loja.Events.FileUpload
{
    public class FileType 
    {
        [JsonIgnore]
        public string Value { get;  set; }
        public virtual string Type { get; set; }    
        public FileType() {}

        public FileType(string value)
        {
            Value = value;
            var json = JsonSerializer.Deserialize<FileType>(value);
            Type = json.Type;
        }
        public static implicit operator string(FileType ft) => ft.Value;
        public virtual void SerializeFileProperties()
        {
            Value = JsonSerializer.Serialize(this);
        }

        /// <summary>
        /// Object type selection must remain as SSOT
        /// </summary>
        /// <param name="ft"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected Type ChooseFileTypeRestriction(FileType ft)
        {
            switch (ft.Type)
            {
                case "Pdf": return typeof(Pdf);
                case "Image": return typeof(Image);
                case "Excel": return typeof(Excel);
                case "Doc": return typeof(Doc);
                case "Video": return typeof(Video);
                case "ValidExtensions": return typeof(ValidExtensions);
                case "All": return typeof(All);
                default: throw new NotImplementedException();
            }
        }

        private IFileTypeProperty TypeToProperty(Type t , string json)
        {
            List<object> objArray = new();
            objArray.Add(new { Value = json });

            IFileTypeProperty instance = (IFileTypeProperty)Activator.CreateInstance(t , objArray );
            
            return instance;
        }

        private IFileTypeRestriction TypeRestriction(Type t, string json)
        {
            List<object> objArray = new();
            objArray.Add(new { Value = json });

            IFileTypeRestriction instance = (IFileTypeRestriction)Activator.CreateInstance(t, objArray);

            return instance;
        }
        public virtual void CopyFromSerializedObject()
        {
            List<string> notIN = new List<string>() { "Value" ,"Type" };
            
            var props = this.GetType().GetProperties();

            props.Where(x =>  !notIN.Any(n=> n == x.Name) );
        }
    }




}
