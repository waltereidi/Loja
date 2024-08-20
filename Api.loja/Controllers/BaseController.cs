﻿using Api.loja.Contracts;
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
        /// <summary>
        /// Add jwtToken in header if existent on httpContext 
        /// </summary>
        /// <typeparam name="AuthenticationApplicationService.HttpContextSignIn">Creation method reference.</typeparam>
        /// <returns></returns>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //if(User.Claims.Any(c => c.Type == nameof(AuthenticationContract.V1.ClientInfo.token.serializedToken)) )
            //    HttpContext.Request.Headers.Authorization ="Bearer s"+User
            //        .Claims
            //        .First(c => c.Type == nameof(AuthenticationContract.V1.ClientInfo.token.serializedToken))
            //        .Value;
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
