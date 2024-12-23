﻿using Api.loja.Contracts;
using Api.loja.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Api.loja.Contracts.AuthenticationContract;
namespace Api.loja.Controllers.Admin
{
    [Route("api/Admin/Authentication/[action]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly AuthenticationApplicationService _service;
        public AuthenticationController(ILogger<AuthenticationController> logger , AuthenticationApplicationService service ) : base(logger)
        {
            _service = service;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login(V1.Request.LoginRequest login)
            => await HandleRequest(new V1.Request.LoginRequestContext(login, HttpContext.Request.HttpContext.Connection.RemoteIpAddress , HttpContext ), _service.Handle);

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserInfo()
            => await HandleRequest(new V1.Request.GetUserInfo(HttpContext), _service.Handle);

    }
}