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
    public class UploadFile : IFileStrategy where T : class
    {
        private readonly IFormCollection _formCollection;
        private readonly IFormFile _formFile;
        private readonly UploadOptions _options;
        string environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environment.CurrentDirectory;
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
        public IEnumerable<T> Start<T>() where T : class
        {
            IEnumerable<FileInfo> listCreatedFiles = [];
            switch (_options) 
            { 
                case UploadOptions.FormColletion: listCreatedFiles= (IEnumerable<FileInfo>)UploadCollection<FileInfo>();break;
                case UploadOptions.FormFile: listCreatedFiles = (IEnumerable<FileInfo>)UploadCollection<FileInfo>(); break;
            }


            return (IEnumerable<T>)listCreatedFiles;
        }
        private async Task<IEnumerable<T>> UploadCollection<T>() 
        {
            IEnumerable<FileInfo> listCreatedFiles = [];
            foreach (var file in _formCollection.Files)
            {
                string path = Path.Combine(environmentName, Guid.NewGuid().ToString());
                using (Stream fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyToAsync(fileStream);
                    var fi = new FileInfo(path);
                    listCreatedFiles.Append(new FileInfo(path));
                };
            }
            return (IEnumerable<T>)listCreatedFiles;
        }
        private async Task<FileInfo> UploadCollection()
        {
            IEnumerable<FileInfo> listCreatedFiles = [];
            foreach (var file in _formCollection.Files)
            {
                string path = Path.Combine(environmentName, Guid.NewGuid().ToString());
                using (Stream fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyToAsync(fileStream);
                    var fi = new FileInfo(path);
                    listCreatedFiles.Append(new FileInfo(path));
                };
            }
            return (IEnumerable<T>)listCreatedFiles;
        }

    }
}
