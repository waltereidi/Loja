using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using WFileManager.Interfaces;

namespace WFileManager.WriteStrategy
{
    public class UploadFile : IFileStrategy
    {
        private readonly IFormCollection _file;
        string environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environment.CurrentDirectory;
        public UploadFile(IFormCollection file) 
        {
            _file = file;
        }
        public IEnumerable<T> Start<T>() where T : class
        {
            IEnumerable<FileInfo> listCreatedFiels = null; 
            foreach(var file in _file.Files )
            {
                using (Stream fileStream = new FileStream(Path.Combine(environmentName, Guid.NewGuid().ToString() ), FileMode.Create)) 
                {
                    file.CopyTo(fileStream);
                };
            }
            return null;
        }
    }
}
