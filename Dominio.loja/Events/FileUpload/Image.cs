using Dominio.loja.Interfaces.Files;
using static Dominio.loja.Events.FileUpload.FileManagerEvents.FileProperties;

namespace Dominio.loja.Events.FileUpload
{
    public sealed class Image : FileType , IFileTypeRestriction , IFileTypeProperty
    {
        public List<Dimensions> Dimensions { get; set; }
        public override string Type { get => typeof(Image).Name;  }
        public Image(IFileTypeProperty ft) : base (ft.Value)
        { 
            
        }
        
        public Image() { }
  
        public void IsValid(object ft , FileInfo fi)
        {
            Image image = (Image)ft;
            if (!Dimensions.Any())
                return;

            if (!image.Dimensions.Any(x => Dimensions.Any(t => t.height == x.height && t.width == x.width)))
                throw new BadImageFormatException("Image format is not valid");
        }

        public void SetFileProperty(object fp )
        {
            Dimensions = new();
            var dim = (Dimensions)fp;

            Dimensions.Add(dim);
        }
    }
}
