using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFileManager.loja.Utility
{
    public class FileManagerUtility
    {

        public FileManagerUtility()
        {

        }
        public string GetFileExtension(string fileName) => fileName.Substring(fileName.LastIndexOf('.') , fileName.Length- fileName.LastIndexOf('.'));
    }

}
