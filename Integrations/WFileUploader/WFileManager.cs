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

        public WFileManager()
        {
            
        }
        
        public IEnumerable<T>Start<T>(IFileStrategy fileStrategy) where T : class
        {
            return fileStrategy.Start<T>();
        }

    }
}
