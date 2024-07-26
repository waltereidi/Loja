using Api.ServicesManager.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static Api.ServicesManager.Contracts.SMApplicationServicesContract;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Api.ServicesManager.Controllers
{
    [Route("api/ServicesManager/[action]")]
    [ApiController]
    public class ServicesManagerController : BaseController
    {
        private readonly SMApplicationServices _service;
        public ServicesManagerController(ILogger<ServicesManagerController> logger , SMApplicationServices service) :base(logger) 
        {
            _service = service ?? throw new ArgumentNullException($"Could not start service {nameof(SMApplicationServices)}");
        }
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpPost]
        public async Task<IActionResult> StartAllServices(T1.StartAllServices data) => Ok( HandleRequest(data ,_service.Handle));//arrumar depois 

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpGet]
        public  async Task<IActionResult> GetServices() => Ok(await HandleRequest(new T1.GetServices(), _service.Handle));

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpPost]
        public async Task<IActionResult> StartQuartz(T1.StartQuartz cmd ) => Ok(HandleRequest(cmd, _service.Handle));

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpPost]
        public async Task<IActionResult> StopQuartz(T1.StopQuartz cmd) => Ok(HandleRequest(cmd, _service.Handle));
    }
}
