using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Events.FileUpload
{
    public class DirectoryValidExtensions
    {
        private string Value { get; set; }
        public DirectoryValidExtensions() { }
        public DirectoryValidExtensions(string extensions) 
        { 
            Value = extensions;
        }

        public static implicit operator string(DirectoryValidExtensions dve) 
        { 
            return dve.Value;
        }





    }
}
