using Api.loja.Data;
using Dominio.loja.Dto.CustomEntities;
using Dominio.loja.Dto.Requests.AdminControllerRequests;
using Dominio.loja.Interfaces.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Net;
namespace Api.loja.Controllers.Admin
{
    [Route("api/Admin/[action]")]
    [ApiController]
    public class AdminController : BaseController
    {
        private readonly IAdminControllerContext _context;
        private readonly IConfiguration _configuration;
        public AdminController(ILogger<AdminController> logger, StoreContext context , IConfiguration configuration) : base(logger)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost]
        [ProducesResponseType<LoginResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<string>(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [EnableRateLimiting("fixed")]
        [AllowAnonymous]
        public async Task<IActionResult>Login(LoginRequest request)
        {
            try
            {
                var login  = _context.clients.Where(x => x.Email == request.Email && x.Password == request.Password);
                if (!login.Any())
                    return BadRequest("Incorrect email or password");

                var response = new LoginResponse(login.First(), _configuration.GetSection("Jwt:Issuer").Value, _configuration.GetSection("Jwt:Key").Value);
               return Ok(response);   
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> Teste()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}