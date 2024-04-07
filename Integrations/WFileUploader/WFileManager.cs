using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFileManager.Interfaces;

namespace WFileManager
{
    public class WFileManager
    {

        public readonly IFileStrategy _fileStrategy;
        public WFileManager(IFileStrategy fileStrategy)
        {
            _fileStrategy = fileStrategy?? throw new ArgumentNullException("Not provided Interface");
        }
        
        public IEnumerable<FileInfo>Start<T>(IEnumerable<T> files) where T : class
        {
            return _fileStrategy.Start<T>(files);
        }

    }
}
