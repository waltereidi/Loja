using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Events.FileUpload
{
    public class FileManagerEvents
    {
        public record class SaveUploadedFile( IEnumerable<FileManagerEvents.Files> files);
        public record class Files(FileInfo file , string fileName );
    }
}
