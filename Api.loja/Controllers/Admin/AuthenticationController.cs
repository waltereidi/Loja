using Api.loja.Contracts;
using Api.loja.Data;
using Api.loja.Service;
using Dominio.loja.Dto.Models;
using Dominio.loja.Events.Authentication;
using Dominio.loja.Interfaces.Context;
using Microsoft.AspNetCore.Mvc;
namespace Api.loja.Controllers.Admin
{
    [Route("api/Admin/Authentication/[action]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly AuthenticationApplicationService _service;
        public AuthenticationController(ILogger<AuthenticationController> logger , AuthenticationApplicationService service) : base(logger)
        {
            _service = service;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login(AuthenticationContract.V1.LoginRequest login) => Ok(await _service.HandleAuthentication(login));//arrumar depois 



    }
}