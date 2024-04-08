using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFileManager.Interfaces;

namespace WFileManager.loja.ReadStrategy
{
    public class ReadFile : IFileStrategy
    {

        IEnumerable<FileInfo> IFileStrategy.Start<T>(IEnumerable<T> file) 
        {
            throw new NotImplementedException();
        }
    }
}
