using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFileManager.Interfaces;

namespace WFileManager.WriteStrategy
{
    public class UploadFile : IFileStrategy
    {
        private readonly IFormCollection _file; 
        public UploadFile(IFormCollection file) 
        {
            _file = file;
        }
        public IEnumerable<T> Start<T>() where T : class 
        {
            return null;
        }
    }
}
