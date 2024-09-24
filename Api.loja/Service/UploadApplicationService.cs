using Framework.loja.Interfaces;
using Integrations;
using WFileManager.Contracts;
using WFileManager.loja.Interfaces;
using Dominio.loja.Entity.Integrations.WFileManager;
using Api.loja.Data;
using Dominio.loja.Events.FileUpload;
using static Api.loja.Contracts.UploadContract.V1;
using Npoi.Mapper;
using WFileManager.Enum;

namespace Api.loja.Service
{
    public class UploadApplicationService : IApplicationService
    {
        private readonly FileManagerMS _fileUploadService;
        private FileManager _fileManager;
        private readonly StoreContext _context;
        public UploadApplicationService(StoreContext context)
        {
            _fileUploadService = new FileManagerMS();
            _fileManager = new FileManager();
            _context = context;
        }

        public async Task<object?> Handle(object command) => command switch
        {
            UploadFile cmd => HandleUploadFile(cmd) ,
            UploadMultipleFiles cmd => HandleUploadMultipleFiles(cmd),
            _ => Task.CompletedTask
        };
        private FileStorage HandleUploadFile(UploadFile cmd)
        {
            if (cmd.file == null)
                throw new ArgumentNullException();

            FileDirectory directory = GetDirectoryFromReferer(cmd.request );
            IFileStrategy strategy = new WFileManager.loja.WriteStrategy.UploadFile( cmd.file ,directory.DirectoryName , UploadOptions.Image );
            //Create File Physically
            var result = _fileUploadService.Start<Images.UploadResponse>(strategy).First();

            //Put created files response into list
            var i = new FileManagerEvents.CreateFile(result.FullName, result.OriginalFileName , directory);
            _fileManager = ;
             var createdFiles = _fileManager.GetCreatedFile();
            _context.fileStorage.AddRange(createdFiles);
            _context.SaveChanges();

            return createdFiles;
        }
        private void HandleUploadMultipleFilesAndCommit(IEnumerable<UploadContracts.UploadResponse> files)
        {
            files.ForEach(f => f.CommitFile());
            _context.SaveChangesAsync();
        }

        private IEnumerable<FileStorage> HandleUploadMultipleFiles(UploadMultipleFiles cmd)
        {
            List<FileStorage> files = new();
            foreach(var file in cmd.files )
            {
                files.Add(HandleUploadFile(new UploadFile(file, cmd.request)));
            }
            return files;
        }
     
        private FileDirectory GetDirectoryFromReferer(HttpRequest request)
        {
            Uri referer = new Uri(request.Headers.Referer);
            FileDirectory directory =_context.fileDirectory.First(x => x.Referer == referer.LocalPath);

            return directory;
        }
        
    }
}
