using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFileManager.loja.Interfaces;

namespace WFileManager.loja.ReadStrategy
{
    public class ReadFile : IFileStrategy
    {
        private readonly IEnumerable<FileInfo> _fileInfos;
        public ReadFile(string fileName)
        {
            
        }
        public IEnumerable<T> Start<T>() where T : class
        {
            throw new NotImplementedException();
        }

    }
}
