﻿
namespace WFileManager.Contracts
{
    public class UploadContracts
    {
        public class UploadDirectory
        {
            private readonly string Env = Path.Combine(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environment.CurrentDirectory);
            public DirectoryInfo Dir { get; private set; }
            public DirectoryInfo TempDir { get; private set; }
            public UploadDirectory(string dir)
            {
                Dir =new( Path.Combine(Env , dir));
                
                if (!Directory.Exists(Dir.FullName))
                    Directory.CreateDirectory(Dir.FullName);

                TempDir = new (Path.Combine(Dir.FullName, "Temp")); 
                if (!TempDir.Exists)
                    Directory.CreateDirectory(TempDir.FullName);
            }
        }

        public class UploadResponse : IDisposable
        {
            public string OriginalFileName { get; set; }
            public string FileName { get; set; }
            private DateTime CreationTime { get; set; }
            private DateTime CreationTimeUtc { get; set; }
            public DateTime LastWriteTime { get; }
            public DateTime LastWriteTimeUtc { get; }
            public string Extension { get; }
            public UnixFileMode UnixFileMode { get; }
            public bool IsReadOnly { get; }
            public string FullName { get; private set; }
            private DirectoryInfo NonTemporaryDirectory { get; set; }
            public FileInfo NonTemporaryFile { get; set; }
            protected bool Disposed { get; set; } = false;

            public UploadResponse(FileInfo file, string originalFileName , DirectoryInfo nonTemporaryDirectory)
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
                NonTemporaryDirectory = nonTemporaryDirectory;
            }
            public DirectoryInfo GetDirectory() => NonTemporaryDirectory;
            public FileInfo GetFileInfo()
            {
                return NonTemporaryFile ?? new(FullName);
            }
            public void CommitFile()
            {
                var file = new FileInfo(FullName);
                file.MoveTo(Path.Combine(NonTemporaryDirectory.FullName,FileName));
                NonTemporaryFile= new(file.FullName);
            }

            public virtual void Dispose(bool dispose)
            {
                if (Disposed)
                {
                    if (File.Exists(FullName))
                        File.Delete(FullName);
                    Disposed = true;
                }
            }
            ~UploadResponse()
            {
                Dispose(Disposed);
            }
            public void Dispose()
            {
                Dispose(Disposed);
                GC.SuppressFinalize(this);
            }
        }

        
    }
}
