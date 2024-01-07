using Dominio.loja.DTO.Requests;
using Microsoft.AspNetCore.Mvc;


namespace Api.loja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : BaseController
    {
        public StoreController(ILogger<StoreController> logger  ) : base(logger)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetConfiguration()
        {
            return Ok();
        }
    }


}
