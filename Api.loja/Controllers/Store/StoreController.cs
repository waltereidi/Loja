using Api.loja.Data;
using Api.loja.Services;
using Dominio.loja.Dto.CustomEntities;
using Dominio.loja.Dto.Requests.AdminControllerRequests;
using Dominio.loja.Interfaces.Context;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.loja.Controllers.Store
{


    [Route("api/Store/[controller]/[action]")]
    [ApiController]
    public class StoreController : BaseController
    {
        private readonly IStoreControllerContext _context;
        private readonly StoreService _service;
        private readonly IConfiguration _configuration;
        public StoreController(ILogger<StoreController> logger, StoreContext context, IConfiguration configuration) : base(logger)
        {
            _context = context;
            _service = new StoreService(context);
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var query = _context.clients.Where(x => x.Email == loginRequest.Email && x.Password == loginRequest.Password);
            if (query.Any())
            {
                string key = _configuration.GetSection("Jwt").GetSection("Key").Value;
                string issuer = _configuration.GetSection("Jwt").GetSection("Issuer").Value;


                LoginResponse response = new (query.First(), issuer, key);
                return Ok(response);

            }
            return StatusCode((int)HttpStatusCode.Unauthorized);
        }
        [HttpGet]
        public IActionResult GetTest()
        {
            return Ok("sdsd");
        }

    }


}
