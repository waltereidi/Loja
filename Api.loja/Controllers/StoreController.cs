using Dominio.loja.DTO.Requests;
using Microsoft.AspNetCore.Mvc;
using Utils.loja.Queue;

namespace Api.loja.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : BaseController
    {
        private readonly IQueue _queue;
        public StoreController(ILogger<StoreController> logger  ,IQueue queue) : base(logger)
        {
            _queue = queue;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {

            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetConfiguration()
        {
            
            return Ok(_queue.ShowMessage());
        }
    }


}
