using Framwork.loja.Utility.Files;
using System.Text.Json;


namespace Dominio.loja.Events.FileUpload
{
    public class DirectoryRestriction
    {
        private string Value { get; set; }
        private Restrictions Restriction { get; set; }
        private record Restrictions(Image[] image , Video[] video , Pdf[] pdf, Doc[] doc, Excel[] excel , All all ,DirectoryValidExtensions extensions);
        private record All(long max , long min );
        private record Image(int heigth , int width );
        private record Video(int heigth, int width , int length);
        private record Pdf();
        private record Doc();
        private record Excel();
        public DirectoryRestriction() { }
        
        public DirectoryRestriction(string value)
        {
            Restriction = JsonSerializer.Deserialize<Restrictions>(value) ?? throw new ArgumentNullException();

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
            if(Restriction.all.min >0 && Restriction.all.min < file.Length )
            {
                throw new InvalidDataException($"File length smaller than {(string)new ReadableFileLength(file.Length)}");
            }

            if (Restriction.all.max > 0 && Restriction.all.max > file.Length)
            {
                throw new InvalidDataException($"File length bigger than {(string)new ReadableFileLength(file.Length)}");
            }
        }
        


    }
}
