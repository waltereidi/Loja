using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Events.FileUpload
{
    public class DirectoryRestriction
    {
        private string Value { get; set; }

        public DirectoryRestriction() { }
        
        public DirectoryRestriction(string value)
        {
            Value = value;
        }

        public static implicit operator string(DirectoryRestriction dr)
        {
            return dr.Value;
        }

    }
}
