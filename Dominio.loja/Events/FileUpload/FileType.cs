
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
        private Type ChooseFileTypeRestriction()
        {
            switch (Type)
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

        public IFileTypeProperty GetTypeToProperty()
        {
            Type t = ChooseFileTypeRestriction();
            
            List<object> objArray = new();

            objArray.Add(new { Value = Value });

            IFileTypeProperty instance = (IFileTypeProperty)Activator.CreateInstance(t , objArray );
            
            return instance;
        }

        public IFileTypeRestriction GetTypeRestriction()
        {
            Type t = ChooseFileTypeRestriction();

            List<object> objArray = new();

            objArray.Add(new { Value = Value });

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
