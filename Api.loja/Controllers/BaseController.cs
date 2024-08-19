using Api.loja.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Data.Entity.Core;
using System.Security.Authentication;

namespace Api.loja.Controllers
{
    public class BaseController : Controller
    {
        private readonly ILogger<BaseController> _logger;
        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;

        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            //var i = JsonConvert.DeserializeObject<AuthenticationContract.CookiesAuthentication>(User.Claims.FirstOrDefault(c => c.Type == "Authentication").Value);
            object? auth = null;
            if(User.Claims.Any(c => c.Type == "Authentication" ) )
                auth=JsonConvert.DeserializeObject<object>(User.Claims.FirstOrDefault(c => c.Type == "Authentication").Value);
        }
        protected async Task<IActionResult> HandleRequest<T>(T request, Func<T, Task<object?>> handler) where T : class
        {
            try
            {
                var result = await handler(request);
                return Ok(result);
            }
            catch (AuthenticationException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (ObjectNotFoundException ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

    }
}
