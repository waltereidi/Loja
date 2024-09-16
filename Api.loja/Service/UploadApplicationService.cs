using Framework.loja.Interfaces;
using Integrations;
using WFileManager.Contracts;
using WFileManager.loja.Interfaces;
using Dominio.loja.Entity.Integrations.WFileManager;
using Api.loja.Data;
using Dominio.loja.Events.FileUpload;
using static Api.loja.Contracts.UploadContract.V1;
using Npoi.Mapper;
using System.IO;

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
        private IEnumerable<FileStorage> HandleUploadFile(UploadFile cmd)
        {
            if (cmd.file == null)
                throw new ArgumentNullException();

            FileDirectory directory = GetDirectoryFromReferer(cmd.request );
            IFileStrategy strategy = new WFileManager.loja.WriteStrategy.UploadFile( cmd.file ,directory.DirectoryName);
            //Create File Physically
            var result = _fileUploadService.Start<UploadContracts.UploadResponse>(strategy).First();
     
                //Put created files response into list
            _fileManager = new (new FileManagerEvents.CreateFile(new(new(result.FullName), result.OriginalFileName) , directory));
            var createdFiles = _fileManager.GetCreatedFiles();
            _context.fileStorage.AddRange(createdFiles);
            _context.SaveChanges();
            result.CommitFile();

            return createdFiles;
        }

        private IEnumerable<FileStorage> HandleUploadMultipleFiles(UploadMultipleFiles cmd)
        {
            if (!cmd.files.Any())
                throw new ArgumentNullException();
            
            FileDirectory directory = GetDirectoryFromReferer(cmd.request);
            IFileStrategy strategy = new WFileManager.loja.WriteStrategy.UploadFile(cmd.files, directory.DirectoryName);

            var result = _fileUploadService.Start<UploadContracts.UploadResponse>(strategy);
            //Create File Physically

            //Save created files in DataBase
            List<FileManagerEvents.Files> files = result
                .Select(s => new FileManagerEvents.Files( new(s.FullName ) ,  s.OriginalFileName))
                .ToList();

            _fileManager = new(new FileManagerEvents.CreateFiles(  files, directory ));

            var createdFiles = _fileManager.GetCreatedFiles();

            _context.fileStorage.AddRangeAsync(createdFiles);
            result.ForEach(f => f.CommitFile());
            _context.SaveChangesAsync();
            return createdFiles;
       
        }
     
        private FileDirectory GetDirectoryFromReferer(HttpRequest request)
        {
            Uri referer = new Uri(request.Headers.Referer);
            FileDirectory directory =_context.fileDirectory.First(x => x.Referer == referer.LocalPath);

            return directory;
        }
        
    }
}
