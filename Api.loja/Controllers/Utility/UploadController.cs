
using Api.loja.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Api.loja.Contracts.UploadContract.V1;
namespace Api.loja.Controllers.Utility
{
    [Route("api/Utility/[action]")]
    [ApiController]
    //[Authorize]
    public class UploadController : BaseController
    {
        private readonly UploadApplicationService _service; 
        public UploadController(ILogger<BaseController> logger ,UploadApplicationService service) : base(logger)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file ) => Ok(await HandleRequest(new UploadFile(file , HttpContext.Request), _service.Handle));
        [HttpPost]
        public async Task<IActionResult> UploadMultipleFiles(IFormCollection files) => Ok(await HandleRequest(new UploadMultipleFiles(files, HttpContext.Request), _service.Handle));
        
    }

    
}
