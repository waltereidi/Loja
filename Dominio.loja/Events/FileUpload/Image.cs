using static Dominio.loja.Events.FileUpload.FileManagerEvents.FileProperties;

namespace Dominio.loja.Events.FileUpload
{
    public class Image : FileType
    {
        public List<Dimensions> Dimensions { get; set; }
        public Image(int height , int width) 
        {
            Dimensions.Add(new Dimensions(height, width));
        }
        public Image(List<Dimensions> dimensions)
        { 
            Dimensions = dimensions;
        }


        public override void IsValid(object ft)
        {
            Image image = (Image)ft;
            if (!Dimensions.Any())
                return;

            if (image.Dimensions.Any(x => Dimensions.Any(t => t.height == x.height && t.width == x.width)))
                throw new BadImageFormatException("Image format is not valid");
        }


    }
}
