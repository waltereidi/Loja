using Api.ServicesManager.MicroService.QuartzMS;
using Dominio.loja.Events.Authentication;
using Framework.loja.Dto.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.ServicesManager.Controllers
{
    public class BaseController : Controller
    {
        private readonly ILogger<BaseController> _logger;
        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }
        protected async Task<IActionResult> HandleRequest<T>(T request, Func<T, Task<T>> handler) where T : class
        {
            try
            {
                return Ok(handler(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

    }
}
