
namespace Dominio.loja.Events.FileUpload
{
    public class FileType
    {
        public record All(long max, long min);
        public class Image
        {
            public List<Dimensions> Dimensions { get; set; }

            public void IsValid(Image image)
            {
                if (!Dimensions.Any())
                    return;

                if (image.Dimensions.Any(x => Dimensions.Any(t => t.height == x.height && t.width == x.width)))
                    throw new BadImageFormatException("Image format is not valid");
            }
        }

        public record Video
        {
            public List<Dimensions> Dimensions { get; set; }
            public int Duration { get; set; }
        }

        public class Pdf { };
        public record Doc();
        public record Excel();
        public record Dimensions( int height , int width );
    }
}
