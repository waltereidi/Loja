
using Microsoft.AspNetCore.Http;
using WFileManager.Contracts;
using WFileManager.Enum;
using WFileManager.loja.Interfaces;
using WFileManager.loja.Utility;

namespace WFileManager.loja.WriteStrategy
{
   
    public class UploadFile : IFileStrategy
    {
        private readonly IFormFile? _formFile;
        private readonly UploadOptions _options;
        private readonly FileManagerUtility _utils = new ();
        private readonly UploadContracts.UploadDirectory _dir;

        /// <exception cref="ArgumentNullException">
        /// File is not provided
        /// </exception>
        /// <exception cref="IOException">
        /// Error during file save
        /// </exception>
        public UploadFile(IFormFile file , string dir , UploadOptions? option)
        {
            _dir = new(dir);
            _formFile = file ?? throw new ArgumentNullException("File is not provided");
            _options = option??UploadOptions.FormFile;
        }
        
        public IEnumerable<T> Start<T>() where T : class
        {
            switch (_options)
            {
                case UploadOptions.FormFile: return (IEnumerable<T>)UploadFormFile<FileInfo>();
                case UploadOptions.Image: return (IEnumerable<T>)UploadImage<FileInfo>();
                default:throw new InvalidOperationException();
            }
        }
        private IEnumerable<Images.Upload> UploadImage<T>()
        {
            List<Images.Upload> file = new();
            var guid = Guid.NewGuid();
            string path = Path.Combine(_dir.TempDir.FullName, guid.ToString() + _utils.GetFileExtension( _formFile.FileName));
            using (Stream fileStream = new FileStream(path, FileMode.Create))
            {
                _formFile.CopyTo(fileStream);

                var result = new Images.Upload(new FileInfo(path), _formFile.FileName, _dir.Dir);
                file.Add( result );
                return file;
            };
        }
        
        private IEnumerable<UploadContracts.UploadResponse> UploadFormFile<T>()
        {
            List<UploadContracts.UploadResponse> file = new();
            var guid = Guid.NewGuid();
            string path = Path.Combine(_dir.TempDir.FullName,  guid.ToString() + _utils.GetFileExtension( _formFile.FileName) );
            using (Stream fileStream = new FileStream( path , FileMode.Create))
            {
                _formFile.CopyTo(fileStream );
                
                var result = new UploadContracts.UploadResponse(new FileInfo(path), _formFile.FileName , _dir.Dir);
                file.Add(result);
                return file;
            };
        }
    
    }
}
