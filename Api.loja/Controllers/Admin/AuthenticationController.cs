using Api.loja.Contracts;
using Api.loja.Data;
using Api.loja.Service;
using Dominio.loja.Dto.CustomEntities;
using Dominio.loja.Dto.Models;
using Dominio.loja.Interfaces.Context;
using Microsoft.AspNetCore.Mvc;

namespace Api.loja.Controllers.Admin
{
    [Route("api/Admin/[action]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly IAdminControllerContext _context;
        private readonly IConfiguration _configuration;
        private readonly AuthenticationApplicationService _service;
        public AuthenticationController(ILogger<AuthenticationController> logger, StoreContext context , IConfiguration configuration) : base(logger)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost]
        [ProducesResponseType<LoginResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResponseModel>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<ResponseModel>(StatusCodes.Status500InternalServerError)]
        public Task<IActionResult> Login(Authentication.V1.LoginRequest login) => HandleRequest(login, _service.Handle);


    }
}