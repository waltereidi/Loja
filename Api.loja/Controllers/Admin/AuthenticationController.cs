using Api.loja.Contracts;
using Api.loja.Service;
using Microsoft.AspNetCore.Mvc;
using static Api.loja.Contracts.AuthenticationContract;
namespace Api.loja.Controllers.Admin
{
    [Route("api/Admin/Authentication/[action]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly AuthenticationApplicationService _service;
        public AuthenticationController(ILogger<AuthenticationController> logger , AuthenticationApplicationService service ) : base(logger)
        {
            _service = service;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login(V1.Request.LoginRequest login) 
            => await HandleRequest(new V1.Request.LoginRequestContext(login , HttpContext ), _service.Handle);
        





    }
}