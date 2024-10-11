using Dominio.loja.Interfaces.Files;
using System.Runtime.CompilerServices;
using static Dominio.loja.Events.FileUpload.FileManagerEvents.FileProperties;

namespace Dominio.loja.Events.FileUpload
{
    public class Image : FileType , IFileTypeRestriction
    {
        public List<Dimensions> Dimensions { get; set; }
        public string Type { get => typeof(Image).ToString(); }

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
            throw new NotImplementedException();
        }
    }
}
