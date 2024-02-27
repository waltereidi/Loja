using Api.loja.Data;
using Api.loja.Services;
using Dominio.loja.Dto.CustomEntities;
using Dominio.loja.Interfaces.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Net;

namespace Api.loja.Controllers.Admin
{
    [Route("api/Admin/[action]")]
    [ApiController]
    public class AdminController : BaseController
    {
        private readonly IAdminControllerContext _context;
        private readonly IConfiguration _configuration;
        public AdminController(ILogger<AdminController> logger, AdminContext context , IConfiguration configuration) : base(logger)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Login([FromBody]string email ,string password )
        {
            try
            {
                var login  = _context.clients.Where(x => x.Email == email && x.Password == password);
                if (!login.Any())
                    return NotFound();

               var response = new LoginResponse(login.First(), _configuration.GetSection("Jwt:Issuer").Value, _configuration.GetSection("Jwt:Key").Value);
                return Ok(response.ToJson());
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}