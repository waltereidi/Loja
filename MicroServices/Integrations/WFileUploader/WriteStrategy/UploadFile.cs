
using Dominio.loja.Entity.Integrations.WFileManager;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using WFileManager.Contracts;
using WFileManager.Enum;
using WFileManager.loja.Interfaces;
using WFileManager.loja.Utility;

namespace WFileManager.loja.WriteStrategy
{
    public class UploadFile : IFileStrategy
    {

        private readonly IFormCollection _formCollection;
        private readonly IFormFile _formFile;
        private readonly UploadOptions _options;
        private readonly FileDirectory _dir;
        private readonly FileManagerUtility _utils = new ();
        private readonly string _path = Path.Combine(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environment.CurrentDirectory);
        public UploadFile(IFormCollection file , string dir =null) 
        {
            if (!Directory.Exists(dir) && !String.IsNullOrEmpty(dir))
                Directory.CreateDirectory(dir);

            if(Directory.Exists(dir))
                _path = dir;

            _formCollection = file;
            _options = UploadOptions.FormColletion;
        }
        public UploadFile(IFormFile file , string dir = null)
        {
            if (!Directory.Exists(dir) && !String.IsNullOrEmpty(dir))
                Directory.CreateDirectory(dir);

            if (Directory.Exists(dir))
                _path = dir;

            _formFile = file;
            _options = UploadOptions.FormFile;
        }
        
        public IEnumerable<T> Start<T>() where T : class
        {
            switch (_options)
            {
                case UploadOptions.FormColletion: return (IEnumerable<T>)UploadCollection<FileInfo>();
                case UploadOptions.FormFile: return (IEnumerable<T>)UploadFormFile<FileInfo>();
                default:return null;
            }
        }
        private IEnumerable<UploadContracts.UploadResponse> UploadCollection<T>()
        {
            foreach (var file in _formCollection.Files)
            {
                Guid guid = Guid.NewGuid();
                string path = Path.Combine(_path , guid.ToString() + _utils.GetFileExtension(file.FileName));
                using (Stream fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyToAsync(fileStream);
                    var result = new UploadContracts.UploadResponse(new FileInfo(path), file.FileName);
                    yield return result;
                };
            }
        }
        private IEnumerable<UploadContracts.UploadResponse> UploadFormFile<T>()
        {
            List<UploadContracts.UploadResponse> file = new();
            var guid = Guid.NewGuid();
            string path = Path.Combine(_path,  guid.ToString() + _utils.GetFileExtension(_formFile.FileName));
            using (Stream fileStream = new FileStream( path , FileMode.Create))
            {
                _formFile.CopyToAsync(fileStream );
                
                var result = new UploadContracts.UploadResponse(new FileInfo(path), _formFile.FileName);
                file.Add(result);
                return file;
            };
        }

    }
}
