using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using WFileManager.Enum;
using WFileManager.loja.Interfaces;

namespace WFileManager.loja.WriteStrategy
{
    public class UploadFile : IFileStrategy
    {
        private readonly IFormCollection _formCollection;
        private readonly IFormFile _formFile;
        private readonly Stream _stream;
        private readonly UploadOptions _options;
        private readonly string _path = Path.Combine(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environment.CurrentDirectory, Guid.NewGuid().ToString());
        private readonly string _environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environment.CurrentDirectory;
        public UploadFile(IFormCollection file) 
        {
            _formCollection = file;
            _options = UploadOptions.FormColletion;
        }
        public UploadFile(IFormFile file)
        {
            _formFile = file;
            _options = UploadOptions.FormColletion;
        }
        public UploadFile(Stream file) 
        {
            _stream = file;
            _options = UploadOptions.Stream;
        }
        public IEnumerable<T> Start<T>() where T : class
        {
            switch (_options)
            {
                case UploadOptions.FormColletion: return (IEnumerable<T>)UploadCollection<FileInfo>();
                case UploadOptions.FormFile: return (IEnumerable<T>)UploadFormFile<FileInfo>();
                case UploadOptions.Stream: return (IEnumerable<T>)UploadStream<FileInfo>();
                default:return null;
            }
        }
        private IEnumerable<FileInfo> UploadStream<T>()
        {
            using(FileStream fs =File.Create( _path ))
            {
                _stream.CopyTo(fs);
                yield return new FileInfo(_path);
            }
        }

        private IEnumerable<FileInfo> UploadCollection<T>()
        {
            foreach (var file in _formCollection.Files)
            {
                using (Stream fileStream = new FileStream(_path, FileMode.Create))
                {
                    
                    file.CopyToAsync(fileStream);
                    yield return new FileInfo(_path);
                };
            }
        }
        private IEnumerable<FileInfo> UploadFormFile<T>()
        {
            using (Stream fileStream = new FileStream(_path, FileMode.Create))
            {
                _formFile.CopyToAsync(fileStream);
                yield return new FileInfo(_path);
            };
        }

    }
}
