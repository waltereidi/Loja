
using Api.loja.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Api.loja.Contracts.UploadContract.V1;
namespace Api.loja.Controllers.Utility
{
    [Route("api/Utility/[action]")]
    [ApiController]
    [Authorize]
    public class UploadController : BaseController
    {
        private readonly UploadApplicationService _service; 
        public UploadController(ILogger<BaseController> logger ,UploadApplicationService service) : base(logger)
        {
            _service = service;
        }
        [HttpPost]
        public Task<IActionResult> UploadFile(IFormFile file ) =>  HandleRequest(new UploadFile(file , HttpContext.Request), _service.Handle);
        [HttpPost]
        public Task<IActionResult> UploadMultipleFiles(IFormFileCollection files) => HandleRequest(new UploadMultipleFiles(HttpContext.Request.Form.Files, HttpContext.Request), _service.Handle);
        
    }

    
}
