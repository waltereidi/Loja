using Api.loja.Contracts;
using Microsoft.AspNetCore.Authentication;
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
        
        public override ChallengeResult Challenge(AuthenticationProperties properties)
        {
            return base.Challenge(properties);
        }
        public override ChallengeResult Challenge()
        {
            return base.Challenge();
        }
        public override ChallengeResult Challenge(AuthenticationProperties properties, params string[] authenticationSchemes)
        {
            return base.Challenge(properties, authenticationSchemes);
        }
        public override ChallengeResult Challenge(params string[] authenticationSchemes)
        {
            return base.Challenge(authenticationSchemes);
        }
        /// <summary>
        /// Add jwtToken in header if existent on httpContext 
        /// </summary>
        /// <typeparam name="AuthenticationApplicationService.HttpContextSignIn">Creation method reference.</typeparam>
        /// <returns></returns>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (User.Claims.Any(c => c.Type == nameof(AuthenticationContract.V1.ClientInfo.token.serializedToken)))
                HttpContext.Request.Headers.Authorization = "Bearer " + User
                    .Claims
                    .First(c => c.Type == nameof(AuthenticationContract.V1.ClientInfo.token.serializedToken))
                    .Value;
        }
       
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            bool valid = true;
            if (valid)
                await next();
            else
                context.Result = new BadRequestObjectResult("Invalid!");
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
