using Api.loja.Data;
using Api.loja.Services;
using Dominio.loja.Dto.CustomEntities;
using Dominio.loja.Dto.Models;
using Dominio.loja.Dto.Requests;
using Dominio.loja.Interfaces.Context;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.loja.Controllers
{


    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StoreController : BaseController
    {
        private readonly IStoreControllerContext _context;
        private readonly StoreService _service; 
        private readonly IConfiguration _configuration;
        public StoreController(ILogger<StoreController> logger  ,StoreContext context , IConfiguration configuration) : base(logger)
        {
            _context = context;
            _service = new StoreService(context);
            _configuration = configuration; 
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var key = _configuration.GetSection("Jwt").GetSection("Key");
            var issuer =_configuration.GetSection("Jwt").GetSection("Issuer");
            var  query = _context.clients.Where(x => x.Email == loginRequest.Email && x.Password == loginRequest.Password);
            if(query.Any())
            {
                LoginResponse response=new LoginResponse( query.First(),issuer.Value , key.Value ) ;
                return Ok(response);
            }
            return StatusCode((int)HttpStatusCode.Unauthorized);
        }


    }


}
