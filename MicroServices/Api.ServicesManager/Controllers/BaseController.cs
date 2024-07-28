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
        protected async Task<object?> HandleRequest<T>(T request, Func<T, Task<object?>> handler) where T : class
        {
            try
            {
                return handler(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

    }
}
