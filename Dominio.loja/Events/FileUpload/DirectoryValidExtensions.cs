namespace Dominio.loja.Events.FileUpload
{
    public class DirectoryValidExtensions
    {
        private string Value { get; set; }
        private string[] Extensions { get; set; }
        public DirectoryValidExtensions() { }
        public DirectoryValidExtensions(string value) 
        {
            Extensions = value.Split(';');
            Value = value;
        }

        public static implicit operator string(DirectoryValidExtensions dve) 
        { 
            return dve.Value;
        }
        public void Validate(FileInfo file)
        {
            if (Extensions.Any(x => file.Extension.Contains(x)))
                throw new InvalidDataException("File extensions does not match");
        }

    }
}
