
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
        protected FileManagerLog _log = new();

        /// <exception cref="ArgumentNullException">
        /// File is not provided
        /// </exception>
        /// <exception cref="IOException">
        /// Error during file save
        /// </exception>
        public UploadFile(IFormFile file , string dir , UploadOptions? option)
        {
            _log.AddEvent("Service started", true);
            _dir = new(dir);
            _log.AddEvent($"Added directory {dir}", true);
            _formFile = file ?? throw new ArgumentNullException("File is not provided");
            _log.AddEvent($"Added formfile {nameof(file)}", true);

            _options = option??UploadOptions.FormFile;
        }
        
        public async Task<IEnumerable<T>> Start<T>() where T : class
        {
            _log.AddEvent($"Upload switch started", true);
            switch (_options)
            {
                case UploadOptions.FormFile: return (IEnumerable<T>)await UploadFormFile<FileInfo>();
                case UploadOptions.Image: return (IEnumerable<T>)await UploadImage<FileInfo>();
                default:throw new InvalidOperationException();
            }
        }
        private async Task<IEnumerable<Images.UploadResponse>> UploadImage<T>()
        {
            _log.AddEvent($"Upload image started", true);
            List<Images.UploadResponse> file = new();
            var guid = Guid.NewGuid();
            string path = Path.Combine(_dir.TempDir.FullName, guid.ToString() + _utils.GetFileExtension( _formFile.FileName));
            using (Stream fileStream = new FileStream(path, FileMode.Create))
            {
                _log.AddEvent($"Filestarted to write physically {_formFile.FileName}", true);
                await _formFile.CopyToAsync(fileStream);
            };
            _log.AddEvent($"File write end", true);
            var result = new Images.UploadResponse(new FileInfo(path), _formFile.FileName, _dir.Dir);
            file.Add(result);
            return file;
        }
        
        private async Task<IEnumerable<UploadContracts.UploadResponse>> UploadFormFile<T>()
        {
            _log.AddEvent($"Upload formfile started", true);
            List<UploadContracts.UploadResponse> file = new();
            var guid = Guid.NewGuid();
            string path = Path.Combine(_dir.TempDir.FullName,  guid.ToString() + _utils.GetFileExtension( _formFile.FileName) );
            using (Stream fileStream = new FileStream( path , FileMode.Create))
            {
                _log.AddEvent($"Filestarted to write physically {_formFile.FileName}", true);
                _formFile.CopyTo(fileStream );
                
                var result = new UploadContracts.UploadResponse(new FileInfo(path), _formFile.FileName , _dir.Dir);
                file.Add(result);
                _log.AddEvent($"File write end", true);
                return file;
            };
        }

        public FileManagerLog GetLog() => _log; 
        
    }
}
