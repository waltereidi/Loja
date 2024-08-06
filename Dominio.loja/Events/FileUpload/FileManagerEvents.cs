﻿using Dominio.loja.Entity.Integrations.WFileManager;
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
        public record class CreateFiles(List<FileInfo> fi, FileDirectory fd);
        public record class SaveUploadedFile( IEnumerable<FileManagerEvents.Files> files);
        public record class Files(FileInfo file , string fileName );
        public record class CreateFile(FileInfo fi, FileDirectory fd);
    }
}
