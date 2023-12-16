using Api.loja.Services;
using Dominio.loja.Dto.CustomEntities;
using Dominio.loja.DTO.Requests;
using Dominio.loja.Entity;
using Dominio.loja.Interfaces.Context;
using Dominio.loja.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;


namespace Api.loja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : BaseController
    {
        private readonly IStore _service;
        private readonly IConfiguration _config;
        public StoreController(ILogger<StoreController> logger ,IConfiguration config ) : base(logger)
        {
            IStore _service = new Store();
            _config = config;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            loginRequest.issuer = _config["Jwt:Issuer"];
            loginRequest.jwtKey = _config["Jwt:Key"];

            return Ok(ClientsPermission.permissionsList) ;
        }
        [HttpGet]
        public IActionResult GetConfiguration()
        {
            return Ok();
        }
    }


}
