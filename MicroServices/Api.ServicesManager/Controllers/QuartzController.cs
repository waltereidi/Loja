using Api.ServicesManager.Interfaces;
using Api.ServicesManager.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static Api.ServicesManager.Contracts.QuartzApplicationServicesContract;

namespace Api.ServicesManager.Controllers
{
    [Route("api/ServicesManager/[action]")]
    [ApiController]
    public class QuartzController : BaseController
    {
        private readonly QuartzApplicationServices _service;
        public QuartzController(ILogger<ServicesManagerController> logger , IHostedServices hostedServices ) :base(logger) 
        {
            _service = new QuartzApplicationServices(hostedServices)?? throw new ArgumentNullException($"Could not start service {nameof(SMApplicationServices)}");
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpPost]
        public async Task<IActionResult> StartQuartz(T1.StartQuartz cmd ) 
            => Ok(await HandleRequest(cmd, _service.Handle));

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpPost]
        public async Task<IActionResult> StopQuartz(T1.StopQuartz cmd) 
            => Ok(await HandleRequest(cmd, _service.Handle));

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpGet]
        public async Task<IActionResult> GetQuartzState()
            => Ok(await HandleRequest(new T1.GetQuartzState(), _service.Handle));


    }
}
