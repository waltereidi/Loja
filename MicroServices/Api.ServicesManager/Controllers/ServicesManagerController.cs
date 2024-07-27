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
        public async Task<IActionResult> StartAllServices(T1.StartAllServices data) 
            => Ok( await HandleRequest(data ,_service.Handle));//arrumar depois 

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpPost]
        public async Task<IActionResult> StopAllServices(T1.StopAllServices data) 
            => Ok(await HandleRequest(data, _service.Handle));//arrumar depois 

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpGet]
        public async Task<IActionResult> GetAllServicesState() 
            => Ok(await HandleRequest(new T1.GetAllServicesState(), _service.Handle));

    }
}
