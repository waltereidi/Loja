using Dominio.loja.Events.FileUpload;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Interfaces.Files
{
    public interface IFileTypeProperty
    {
        void SetFileProperty(object fp);
        string Type { get; set; }
        string Value { get; set; }  
    }
}
