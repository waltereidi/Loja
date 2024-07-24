using Api.ServicesManager.Contracts;
using Api.ServicesManager.MicroService.QuartzMS;
using Api.ServicesManager.Services;
using Dominio.loja.Events.Authentication;
using Framework.loja.Dto.Models;
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
        public ServicesManagerController(ILogger<ServicesManagerController> logger , SMApplicationServices service) :base(logger) 
        {
            _service = service ?? throw new ArgumentNullException($"Could not start service {nameof(SMApplicationServices)}");
        }
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpPost]
        public async Task<IActionResult> StartAllServices(T1.StartAllServices data) => Ok( _service.Handle(data));//arrumar depois 

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpGet]
        public async Task<IActionResult> GetServices() => Ok(_service.Handle(new T1.GetServices()));

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpPost]
        public async Task<IActionResult> StartQuartz(T1.StartQuartz cmd ) => Ok(_service.Handle(cmd));
    }
}
