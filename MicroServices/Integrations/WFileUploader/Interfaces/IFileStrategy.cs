using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFileManager.Contracts;

namespace WFileManager.loja.Interfaces
{
    public interface IFileStrategy
    {
        Task<IEnumerable<T>> Start<T>() where T : class;
        FileManagerLog GetLog();
    }
}
