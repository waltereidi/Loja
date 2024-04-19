using Dominio.loja.Interfaces.Context;
using Microsoft.AspNetCore.Mvc;

namespace Api.loja.Controllers
{
    public class BaseController : Controller
    {
        private readonly ILogger<BaseController> _logger;
        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;

        }
        private async Task<IActionResult> HandleRequest<T>(T request, Func<T, Task> handler)
        {
            try
            {
                await handler(request);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }
    }
}
