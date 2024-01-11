using Dominio.loja.DTO.Requests;
using Microsoft.AspNetCore.Mvc;
using NPOI.OpenXmlFormats.Spreadsheet;
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
        [Route("/[controller]/[action]")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {

            return Ok();
        }
        [Route("/[controller]/[action]")]
        [HttpGet]
        public async Task<IActionResult> GetConfiguration()
        {
            
            _queue.ShowMessage();
            return Ok();
        }
        [Route("/[controller]/[action]")]
        [HttpGet]
        public async Task<IActionResult> CreateSecondTask()
        {
            _queue.counter++;
            _queue.ShowMessage();
            return Ok();
        }
        [Route("/[controller]/[action]")]
        [HttpGet]
        public async Task<IActionResult> GetTaskResult()
        {
            return Ok(_queue.StoredResults);
        }
        [Route("/[controller]/[action]")]
        [HttpGet]
        public async Task<IActionResult> GetStoredThreads()
        {
            return Ok(_queue.StoredThreads.ToString());
        }
        [Route("/[controller]/[action]")]
        [HttpGet]
        public async Task<IActionResult> KillThread()
        {
            _queue.KillThread();
            return Ok();
        }
    }


}
