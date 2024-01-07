using Dominio.loja.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.loja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreClientsController : BaseController
    {
        public StoreClientsController(ILogger<StoreClientsController> logger  ) : base(logger)
        {
        }
        
        [HttpGet]
        [Authorize]
        [Route("/[controller]/[action]")]
        public async Task<IActionResult> GetEditMyProfile([FromHeader]int ID_Clients)
        {

            return Ok();
        }

        [HttpPut]
        [Authorize]
        [Route("/[controller]/[action]")]
        public async Task<IActionResult> PutEditMyProfile([FromBody] Clients dataSource)
        {

            return Ok();
        }
        [HttpGet]
        [Authorize]
        [Route("/[controller]/[action]")]
        public async Task<IActionResult> GetOrdersRequest([FromHeader] int ID_Clients )
        {
            return Ok();

        }
        [HttpPost]
        [Authorize]
        [Route("/[controller]/[action]")]
        public async Task<IActionResult> PostOrdersRequest([FromBody] int dataSource )
        {
            return Ok();
        }

        [HttpPut]
        [Authorize]
        [Route("/[controller]/[action]")]
        public async Task<IActionResult> PutCartProducts()
        {
            return Ok();
        }
        [HttpDelete]
        [Authorize]
        [Route("/[controller]/[action]")]
        public async Task<IActionResult> DeleteCartProducts()
        {
            return Ok();
        }
        [HttpDelete]
        [Authorize]
        [Route("/[controller]/[action]")]
        public async Task<IActionResult> GetCartProducts()
        {
            return Ok();
        }

     }
}
