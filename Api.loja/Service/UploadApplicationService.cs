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
            UploadFile cmd => HandleUploadFile(cmd),
            UploadMultipleFiles cmd => HandleUploadMultipleFiles(cmd),
            _ => Task.CompletedTask
        };
        private async Task HandleUploadFile(UploadFile cmd)
        {
            
            GetDirectoryFromReferer(cmd.request , cmd.file.Headers["Content-Type"].First() );
            IFileStrategy strategy = new WFileManager.loja.WriteStrategy.UploadFile( cmd.file );
            var result = fileUploadService.Start<UploadContracts.UploadResponse>(strategy);
      
        }

        private void GetDirectoryFromReferer(HttpRequest request, string? content)
        {
            Uri referer =new Uri(request.Headers.Referer);

            var i = _context.fileDirectory.First();
            if (!_context.fileDirectory.Any(x => x.Referer == referer.LocalPath && x.ValidExtensions.Contains(content)))
                throw new InvalidDataException("Invalid data exception");
        }

        private async Task HandleUploadMultipleFiles(UploadMultipleFiles cmd)
        {
            IFileStrategy strategy = new WFileManager.loja.WriteStrategy.UploadFile(cmd.files);
            var result = fileUploadService.Start<UploadContracts.UploadResponse>(strategy);
        }
    }
}
