using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Events.Integracoes.WFileManager
{
    public  class FileManagerEvents : Events
    {
        public class FileUploaded
        { 
            public IFormFile FormFile;
        
        }

    }
}
