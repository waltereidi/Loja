﻿using Framework.loja.Dto.Models;
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
        protected async Task<IActionResult> HandleRequest<T>(T request, Func<T, Task<ControllerResponse<T>>> handler) where T : class
        {
            try
            {
                ControllerResponse<T> response = await handler(request);
                return StatusCode((int)response.StatusCode , response.Response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }
    }
}
