
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

        private readonly IFormCollection? _formCollection;
        private readonly IFormFile? _formFile;
        private readonly IFormFile?[] _formFiles;
        private readonly UploadOptions _options;
        private readonly FileManagerUtility _utils = new ();
        private readonly UploadContracts.UploadDirectory _dir; 

        public UploadFile(IFormCollection file , string dir) 
        {
            _dir = new(dir);
            _formCollection = file;
            _options = UploadOptions.FormColletion;
        }
        public UploadFile(IFormFile file , string dir)
        {
            _dir = new(dir);
            _formFile = file;
            _options = UploadOptions.FormFile;
        }
        public UploadFile(IFormFile[] file, string dir)
        {
            _dir = new(dir);
            _formFiles = file;
            _options = UploadOptions.FormFileArray;
        }
        public IEnumerable<T> Start<T>() where T : class
        {
            switch (_options)
            {
                case UploadOptions.FormColletion: return (IEnumerable<T>)UploadCollection<FileInfo>();
                case UploadOptions.FormFile: return (IEnumerable<T>)UploadFormFile<FileInfo>();
                case UploadOptions.FormFileArray: return (IEnumerable<T>)UploadFormFileArray<FileInfo>();
                default:throw new InvalidOperationException();
            }
        }
        private IEnumerable<UploadContracts.UploadResponse> UploadCollection<T>()
        {
            foreach (var file in _formCollection.Files)
            {
                Guid guid = Guid.NewGuid();
                string path = Path.Combine(_dir.TempDir.FullName , guid.ToString() + _utils.GetFileExtension(file.FileName));
                using (Stream fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyToAsync(fileStream);
                    var result = new UploadContracts.UploadResponse(new FileInfo(path), file.FileName , _dir.Dir);
                    yield return result;
                };
            }
        }
        private IEnumerable<UploadContracts.UploadResponse> UploadFormFile<T>()
        {
            List<UploadContracts.UploadResponse> file = new();
            var guid = Guid.NewGuid();
            string path = Path.Combine(_dir.TempDir.FullName,  guid.ToString() + _utils.GetFileExtension(_formFile.FileName) );
            using (Stream fileStream = new FileStream( path , FileMode.Create))
            {
                _formFile.CopyToAsync(fileStream );
                
                var result = new UploadContracts.UploadResponse(new FileInfo(path), _formFile.FileName , _dir.Dir);
                file.Add(result);
                return file;
            };
        }
        private IEnumerable<UploadContracts.UploadResponse> UploadFormFileArray<T>()
        {
            List<UploadContracts.UploadResponse> files = new();
            var guid = Guid.NewGuid();
            foreach (var item in _formFiles)
            {
                string path = Path.Combine(_dir.TempDir.FullName, guid.ToString() + _utils.GetFileExtension(item.FileName) );

                using (Stream fileStream = new FileStream(path, FileMode.Create))
                {
                    item.CopyToAsync(fileStream);

                    var result = new UploadContracts.UploadResponse(new FileInfo(path), item.FileName , _dir.Dir);
                    files.Add(result);
                };
            }
            return files;
        }
        
    }
}
