using Microsoft.IdentityModel.Tokens;

namespace Dominio.loja.Events.FileUpload
{
    public class FileManagerEvents
    {
        public class CategoryChangedPicture : CreateFile
        {
            public CategoryChangedPicture(string fullName, string originalName, string directory) : base(fullName, originalName, directory)
            {
            }

        }
        
        public class CreateFile
        {
            public FileInfo FileInfo { get; set; }
            public string OriginalName { get; set; }
            public CreateFile(string fullName ,string originalName , string directory )
            {
                if (originalName.IsNullOrEmpty())
                    throw new ArgumentNullException($"original name cannot be null or empty {nameof(originalName)}");

                if (originalName.IsNullOrEmpty())
                    throw new ArgumentNullException($"original name cannot be null or empty {nameof(originalName)}");

                FileInfo = new FileInfo(fullName);
                OriginalName = originalName; 
            }
        }
    }
}
