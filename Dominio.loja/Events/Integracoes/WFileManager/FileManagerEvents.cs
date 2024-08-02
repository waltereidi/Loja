using Microsoft.AspNetCore.Http;

namespace Dominio.loja.Events.Integracoes.WFileManager
{
    public  class FileManagerEvents 
    {
        public record class FileUploaded(IEnumerable<FileInfo> FormFile);
        

    }
}
