using Api.loja.Data;
using Api.loja.Services;
using Dominio.loja.Dto.CustomEntities;
using Dominio.loja.Dto.Requests;
using Dominio.loja.Entity;
using Dominio.loja.Interfaces.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NuGet.Protocol;
using System.Net;

namespace Api.loja.Controllers.Admin
{
    [Route("api/Admin/Store/Categories/[action]")]
    [Authorize]
    public class StoreCategoriesController : BaseController
    {
        private readonly IAdminStoreCategoriesControllerContext _context;
        private readonly IConfiguration _configuration;
        public StoreCategoriesController(ILogger<BaseController> logger , AdminContext context ) : base(logger)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetCategories()
        {
            try
            {
                return Ok(_context.categories.Any()? _context.categories.ToList() : null);
            }catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError , ex.Message);
            }
        }
    }
}
