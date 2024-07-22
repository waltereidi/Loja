using Api.ServicesManager.Contracts;
using Api.ServicesManager.MicroService.QuartzMS;
using Api.ServicesManager.Services;
using Dominio.loja.Events.Authentication;
using Framework.loja.Dto.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.ServicesManager.Controllers
{
    [Route("api/ServicesManager/[action]")]
    [ApiController]
    public class ServicesManagerController : Controller
    {
        private readonly ILogger<ServicesManagerController> _logger;
        private readonly SMApplicationServices _service = new SMApplicationServices();
        public ServicesManagerController(ILogger<ServicesManagerController> logger)
        {
            _logger = logger;
        }
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpPost]
        public async Task<IActionResult> StartAllServices(TopShelfContract data) => Ok( _service.Handle(data));//arrumar depois 
    }
}
