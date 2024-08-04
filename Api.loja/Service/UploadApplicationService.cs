using Framework.loja.Interfaces;
using static Api.loja.Contracts.UploadContract.V1;
using Integrations;
using WFileManager.Contracts;
using WFileManager.loja.Interfaces;
using Dominio.loja.Entity.Integrations.WFileManager;
using Api.loja.Data;
using Dominio.loja.Events.FileUpload;

namespace Api.loja.Service
{
    public class UploadApplicationService : IApplicationService
    {
        private readonly FileManagerMS _fileUploadService;
        private FileManager _fileManager;
        private readonly StoreContext _context;
        public UploadApplicationService(IConfiguration configuration, StoreContext context)
        {
            _fileUploadService = new FileManagerMS();
            _context = context;
        }

        public async Task<object?> Handle(object command) => command switch
        {
            UploadFile cmd => HandleUploadFile(cmd) ,
            UploadMultipleFiles cmd => HandleUploadMultipleFiles(cmd),
            _ => Task.CompletedTask
        };
        private IEnumerable<UploadContracts.UploadResponse> HandleUploadFile(UploadFile cmd)
        {
            FileDirectory directory = GetDirectoryFromReferer(cmd.request , cmd.file.ContentType );
            IFileStrategy strategy = new WFileManager.loja.WriteStrategy.UploadFile( cmd.file ,directory.DirectoryName);
            
            var result = _fileUploadService.Start<UploadContracts.UploadResponse>(strategy);

            return result;
        }

        private FileDirectory GetDirectoryFromReferer(HttpRequest request, string content)
        {
            Uri referer =new Uri(request.Headers.Referer);

            if (!_context.fileDirectory.Any(x => x.Referer == referer.LocalPath && x.ValidExtensions.Contains(content)))
                throw new InvalidDataException("File type not allowed");

            return _context.fileDirectory.First(x=> x.Referer == referer.LocalPath && x.ValidExtensions.Contains(content));
        }

        private UploadContracts.UploadResponse HandleUploadMultipleFiles(UploadMultipleFiles cmd)
        {
            FileDirectory directory = GetDirectoryFromReferer(cmd.request, cmd.files);
            IFileStrategy strategy = new WFileManager.loja.WriteStrategy.UploadFile(cmd.files, directory.DirectoryName);

            var result = _fileUploadService.Start<UploadContracts.UploadResponse>(strategy).First();
            var fileList = new List<FileInfo>();
            fileList.Add(result.GetFileInfo());

            _fileManager = new(new FileManagerEvents.CreateFiles(fileList , directory));

            return result;
        }

        private FileDirectory GetDirectoryFromReferer(HttpRequest request, IFormFile[] files)
        {
            Uri referer = new Uri(request.Headers.Referer);
            FileDirectory directory =_context.fileDirectory.First(x => x.Referer == referer.LocalPath);
            foreach (var file in files) 
            {
                if (!directory.ValidExtensions.Contains(file.ContentType))
                    throw new InvalidDataException("File type not allowed");
            }

            return directory;

        }
    }
}
