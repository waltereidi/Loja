using Api.loja.Contracts;
using Api.loja.Data;
using Api.loja.Service;
using Dominio.loja.Dto.Models;
using Dominio.loja.Events.Authentication;
using Dominio.loja.Interfaces.Context;
using Microsoft.AspNetCore.Mvc;

namespace Api.loja.Controllers.Admin
{
    [Route("api/Admin/[action]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        private readonly PraedicamentaApplicationService _service;
        public CategoriesController(ILogger<CategoriesController> logger) : base(logger)
        {
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<IActionResult> Login(PraedicamentaContract.V1.AddCategories category) => HandleRequest(category, _service.Handle);

        [HttpGet]
        [ProducesResponseType<LoginAdmin>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll() => Ok(_service.GetAll());
        

    }
}