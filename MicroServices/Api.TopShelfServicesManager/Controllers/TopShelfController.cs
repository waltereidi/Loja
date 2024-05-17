using Microsoft.AspNetCore.Mvc;
using System.ServiceProcess;

namespace Api.TopShelfServicesManager.Controllers
{
    public class TopShelfController : Controller
    {
        ILogger _logger; 
        public TopShelfController( ILogger<TopShelfController> logger ) 
        {
            _logger = logger ?? throw new ArgumentNullException();
        }
        public async Task<IActionResult> StartService()
        {
            return Ok();
        }
    }
}
