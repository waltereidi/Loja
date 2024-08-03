using Framework.loja.Interfaces;
using static Api.loja.Contracts.UploadContract.V1;
using Integrations;
using WFileManager.Contracts;
using WFileManager.loja.Interfaces;
using Dominio.loja.Entity.Integrations.WFileManager;
using Api.loja.Data;
using System.Data.Entity;

namespace Api.loja.Service
{
    public class UploadApplicationService : IApplicationService
    {
        private readonly FileManager fileUploadService;
        private readonly StoreContext _context;
        public UploadApplicationService(IConfiguration configuration, StoreContext context)
        {
            fileUploadService = new FileManager();
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
            FileDirectory directory = GetDirectoryFromReferer(cmd.request , cmd.file.Headers["Content-Type"].First() );
            IFileStrategy strategy = new WFileManager.loja.WriteStrategy.UploadFile( cmd.file ,directory.DirectoryName);
            
            var result = fileUploadService.Start<UploadContracts.UploadResponse>(strategy);

            return result;
        }

        private FileDirectory GetDirectoryFromReferer(HttpRequest request, string? content)
        {
            Uri referer =new Uri(request.Headers.Referer);

            if (!_context.fileDirectory.Any(x => x.Referer == referer.LocalPath && x.ValidExtensions.Contains(content)))
                throw new InvalidDataException("Invalid data exception");

            return _context.fileDirectory.First(x=> x.Referer == referer.LocalPath && x.ValidExtensions.Contains(content));
        }

        private async Task HandleUploadMultipleFiles(UploadMultipleFiles cmd)
        {
            IFileStrategy strategy = new WFileManager.loja.WriteStrategy.UploadFile(cmd.files);
            var result = fileUploadService.Start<UploadContracts.UploadResponse>(strategy);
        }
    }
}
