using Framwork.loja.Utility.Files;
using System.Text.Json;


namespace Dominio.loja.Events.FileUpload
{
    public class DirectoryRestriction
    {
        private string Value { get; set; }
        private SerializedRestrictions SerializedValue { get; set; }
        private record SerializedRestrictions(Image[] image , Video[] video , Pdf[] pdf, Doc[] doc, Excel[] excel , All all );
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
        public void Validate(FileInfo file)
        {
            ValidateGeneralRestrictions(file);
            

            throw new Exception("Invalid file");
        }
        private void ValidateFileType()
        {

        }
        private void ValidateGeneralRestrictions(FileInfo file)
        {
            if(SerializedValue.all.min >0 && SerializedValue.all.min < file.Length )
            {
                throw new InvalidDataException($"File length smaller than {(string)new ReadableFileLength(file.Length)}");
            }

            if (SerializedValue.all.max > 0 && SerializedValue.all.max > file.Length)
            {
                throw new InvalidDataException($"File length bigger than {(string)new ReadableFileLength(file.Length)}");
            }
        }
        


    }
}
