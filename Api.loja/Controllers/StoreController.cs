using Api.loja.Services;
using Dominio.loja.DTO.Requests;
using Dominio.loja.Interfaces.Context;
using Microsoft.AspNetCore.Mvc;
using NPOI.OpenXmlFormats.Spreadsheet;
using Utils.loja.Queue;

namespace Api.loja.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : BaseController
    {
        private readonly IStoreControllerContext _context;
        private readonly StoreService service; 
        public StoreController(ILogger<StoreController> logger  ,IStoreContext context) : base(logger)
        {
            _context = context;
            service = new StoreService();
        }

        [HttpPost]
        [Route("/[controller]/[action]")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest )
        {

            return Ok();
        }
     
    }


}
