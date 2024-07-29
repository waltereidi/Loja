using Api.ServicesManager.Interfaces;
using Api.ServicesManager.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static Api.ServicesManager.Contracts.SMApplicationServicesContract;

namespace Api.ServicesManager.Controllers
{
    [Route("api/ServicesManager/[action]")]
    [ApiController]
    public class ServicesManagerController : BaseController
    {
        private readonly SMApplicationServices _service;
        public ServicesManagerController(ILogger<ServicesManagerController> logger , IHostedServices hostedServices ) :base(logger) 
        {
            _service = new SMApplicationServices(hostedServices) 
                ?? throw new ArgumentNullException($"Could not start service {nameof(SMApplicationServices)}");
        }
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpPost]
        public async Task<IActionResult> StartAllServices(T1.StartAllServices cmd)
        {
            HandleRequest(cmd, _service.Handle);
            return Ok("Attempt to start all services was sent");
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpPost]
        public async Task<IActionResult> StopAllServices(T1.StopAllServices cmd)
        {
            HandleRequest(cmd, _service.Handle);
            return Ok("Attempt to stop all services was sent");
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpGet]
        public async Task<IActionResult> GetAllServicesState() 
            => Ok(await HandleRequest(new T1.GetAllServicesState(), _service.Handle));

    }
}
