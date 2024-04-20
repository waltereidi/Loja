using Microsoft.AspNetCore.Http;

namespace Dominio.loja.Events.Integracoes.WFileManager
{
    public  class FileManagerEvents 
    {
        public class FileUploaded
        { 
            public IFormFile FormFile;
        
        }

    }
}
