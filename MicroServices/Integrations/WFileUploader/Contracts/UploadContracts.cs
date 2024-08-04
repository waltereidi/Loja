using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFileManager.Contracts
{
    public class UploadContracts
    {
        public record class FileInfoResponse();

        public class UploadResponse 
        {
            private string OriginalFileName { get; set; }
            private string FileName { get; set; }
            private DateTime CreationTime { get; set; }
            private DateTime CreationTimeUtc { get; set; }
            public DateTime LastWriteTime { get; }
            public DateTime LastWriteTimeUtc { get; }
            public string Extension { get; }
            public UnixFileMode UnixFileMode { get; }
            public bool IsReadOnly { get; }
            private string FullName { get; set; }

            public UploadResponse(FileInfo file, string originalFileName)
            {
                OriginalFileName = originalFileName;
                FileName = file.Name;
                CreationTime = file.CreationTime;
                CreationTimeUtc = file.CreationTimeUtc;
                LastWriteTime = file.LastWriteTime;
                LastWriteTimeUtc = file.LastWriteTimeUtc;
                Extension = file.Extension;
                UnixFileMode = file.UnixFileMode;
                IsReadOnly = file.IsReadOnly;
                FullName = file.FullName;
            }
            public FileInfo GetFileInfo()
            {
                return new FileInfo(FullName);
            }
            
        }

        
    }
}
