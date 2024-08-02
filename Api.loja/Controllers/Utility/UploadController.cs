
using Api.loja.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Api.loja.Contracts.UploadContract.V1;
namespace Api.loja.Controllers.Utility
{
    [Authorize]
    public class UploadController : BaseController
    {
        private readonly UploadApplicationService _service; 
        public UploadController(ILogger<BaseController> logger) : base(logger)
        {
            _service = new UploadApplicationService();
        }
        public async Task<IActionResult> UploadFile(IFormFile file) => Ok(await HandleRequest(new UploadFile(file), _service.Handle));
        public async Task<IActionResult> UploadMultipleFiles(IFormCollection files) => Ok(await HandleRequest(new UploadMultipleFiles(files), _service.Handle));
        
    }

    
}
