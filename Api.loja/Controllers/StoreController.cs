using Dominio.loja.DTO.Requests;
using Dominio.loja.Entity;
using Dominio.loja.Interfaces.Context;
using Microsoft.AspNetCore.Mvc;


namespace Api.loja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : BaseController
    {
        private IConfiguration _config;
        private IStoreContext _context;
        public StoreController(ILogger<StoreController> logger, IConfiguration config, IStoreContext context) : base(logger)
        {
            _config = config;
            _context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] JwtTokenRequest loginRequest)
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
