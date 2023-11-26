using Api.loja.Services;
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
        IStore _service;
        public StoreController(ILogger<StoreController> logger  , IStore _service ) : base(logger)
        {
            IStore _service = new Store();
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {

            Clients client = _context.getClient(loginRequest.Login, loginRequest.Password);
            loginRequest.Clients = client;
            loginRequest.issuer = _config["Jwt:Issuer"];
            loginRequest.jwtKey = _config["Jwt:Key"];
            var retorno = loginRequest.GetToken();

            return Ok(retorno);
        }
    }


}
