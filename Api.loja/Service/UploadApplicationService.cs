using Api.loja.Contracts;
using Framework.loja.Interfaces;
using static Api.loja.Contracts.UploadContract.V1;
using WFileManager;
using Integrations;
using Dominio.loja.Events.FileManager;
using NPOI.HPSF;
using System.IO;
using WFileManager.Contracts;
using WFileManager.loja.Interfaces;
namespace Api.loja.Service
{
    public class UploadApplicationService : IApplicationService
    {
        private readonly FileManager fileUploadService;
        
        public UploadApplicationService()
        {
            fileUploadService = new FileManager();
        }

        public async Task<object?> Handle(object command) => command switch
        {
            UploadFile cmd => HandleUploadFile(cmd),
            UploadMultipleFiles cmd => HandleUploadMultipleFiles(cmd),
            _ => Task.CompletedTask
        };
        private async Task HandleUploadFile(UploadFile cmd)
        {
            IFileStrategy strategy = new WFileManager.loja.WriteStrategy.UploadFile( cmd.file );
            var result = fileUploadService.Start<UploadContracts.UploadResponse>(strategy);

            if (result != null) 
            { 
                
            }
        }

        private async Task HandleUploadMultipleFiles(UploadMultipleFiles cmd)
        {
            IFileStrategy strategy = new WFileManager.loja.WriteStrategy.UploadFile(cmd.files);
            var result = fileUploadService.Start<UploadContracts.UploadResponse>(strategy);
        }
    }
}
