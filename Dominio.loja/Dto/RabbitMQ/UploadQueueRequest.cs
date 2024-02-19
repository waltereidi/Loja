using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Dto.RabbitMQ
{
    public class UploadQueueRequest
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public long Length { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpadtedAt { get; set; }
        public UploadQueueRequest(IFormFile formFile, FileInfo fileInfo)
        {
            FileName = formFile.FileName;
            FilePath = fileInfo.FullName;
            Length = formFile.Length;
            CreateAt = fileInfo.CreationTimeUtc;
            UpadtedAt = fileInfo.LastWriteTimeUtc;
        }
    }
}
