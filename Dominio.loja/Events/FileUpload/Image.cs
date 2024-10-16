using Dominio.loja.Interfaces.Files;
using System.Runtime.CompilerServices;
using System.Text.Json;
using static Dominio.loja.Events.FileUpload.FileManagerEvents.FileProperties;

namespace Dominio.loja.Events.FileUpload
{
    public sealed class Image : FileType , IFileTypeRestriction , IFileTypeProperty
    {
        public List<Dimensions> Dimensions { get; set; }
        public override string Type { get => typeof(Image).Name;  }

        public Image(FileType ft) : base((string)ft)
        {
            DeserializeFileProperties();
        }
        public Image(int height , int width) 
        {
            Dimensions= new();
            Dimensions.Add(new Dimensions(height, width));
        }

        public Image(string dimensions)
        { 
            
        }
        
        public Image() { }
  
        public void IsValid(object ft)
        {
            Image image = (Image)ft;
            if (!Dimensions.Any())
                return;

            if (image.Dimensions.Any(x => Dimensions.Any(t => t.height == x.height && t.width == x.width)))
                throw new BadImageFormatException("Image format is not valid");
        }

        public void SerializeFileProperties()
        {
            throw new NotImplementedException();
        }

        public void DeserializeFileProperties()
        {
            Image image= JsonSerializer.Deserialize<Image>(base.Value);
            Dimensions = image?.Dimensions ?? new();
        }
    }
}
