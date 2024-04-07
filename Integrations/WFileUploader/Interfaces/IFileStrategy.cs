using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFileManager.Interfaces
{
    public interface IFileStrategy
    {
        IEnumerable<T> Start<T>() where T : class;
    }
}
