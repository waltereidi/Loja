using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
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
      
        /// <summary>
        /// Add jwtToken in header if existent on httpContext 
        /// </summary>
        /// <typeparam name="AuthenticationApplicationService.HttpContextSignIn">Creation method reference.</typeparam>
        /// <returns></returns>
        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    if (User.Claims.Any(c => c.Type == nameof(AuthenticationContract.V1.ClientInfo.token.serializedToken)))
        //        HttpContext.Request.Headers.Authorization = "Bearer " + User
        //            .Claims
        //            .First(c => c.Type == nameof(AuthenticationContract.V1.ClientInfo.token.serializedToken))
        //            .Value;
        //}
       
     
        protected async Task<IActionResult> HandleRequest<T>(T request, Func<T, Task<object?>> handler) where T : class
        {
            try
            {
                var result = await handler(request);
                return Ok(result);
            }
            //Throw this exception when authentication attempt fails
            catch (AuthenticationException ex)
            {
                return BadRequest(ex.Message);
            }
            //Throw this exception when is required to logoff from application
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            //Throw this exception when an unexpected empty respoonse is required
            catch (ObjectNotFoundException ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(ex.Message);
            }
            //Unhandled exceptions
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

    }
}
