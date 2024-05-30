using Api.TopShelfServicesManager.Contracts;
using Api.TopShelfServicesManager.Services;
using Microsoft.AspNetCore.Mvc;
using System.ServiceProcess;
using static Api.TopShelfServicesManager.Contracts.TopShelfContract;

namespace Api.TopShelfServicesManager.Controllers
{
    [Route("api/TopShelfServicesManager/[action]")]
    public class TopShelfController : BaseController
    {
        //public TopShelfController( ILogger<BaseController> logger  service ) : base(logger)
        //{
        //    _service = service;
        //}
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public Task<IActionResult> StartQuartz(T1.StartQuartz command) => HandleRequest( command , _service.Handle );

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public Task<IActionResult> StopQuartz(T1.StopQuartz command) => HandleRequest(command , _service.Handle );

    }
}
