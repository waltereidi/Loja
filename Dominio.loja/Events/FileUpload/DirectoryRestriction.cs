using System.Text.Json;


namespace Dominio.loja.Events.FileUpload
{
    public class DirectoryRestriction
    {
        private string Value { get; set; }
        private SerializedRestrictions SerializedValue { get; set; }
        private record SerializedRestrictions(Image[] image , Video[] video , Pdf[] pdf, Doc[] doc, Excel[] excel ,All all );
        private record All(long max , long min );
        private record Image(int heigth , int width );
        private record Video(int heigth, int width , int length);
        private record Pdf();
        private record Doc();
        private record Excel();
        public DirectoryRestriction() { }
        
        public DirectoryRestriction(string value)
        {
            SerializedValue = JsonSerializer.Deserialize<SerializedRestrictions>(value) ?? throw new ArgumentNullException();

            Value = value;
        }

        public static implicit operator string(DirectoryRestriction dr)
        {
            return dr.Value;
        }

    }
}
