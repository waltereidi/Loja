using Dominio.loja.Entity;
using Dominio.loja.Entity.Integrations.WFileManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Events.FileUpload
{
    public class FileManagerEvents
    {
        public record CategoryChangedPicture(Files value, FileDirectory directory);
        public record class CreateFiles(List<Files> files , FileDirectory fd);
        public record class Files(FileInfo file , string fileName );
        public record class CreateFile(Files fi, FileDirectory fd );
    }
}
