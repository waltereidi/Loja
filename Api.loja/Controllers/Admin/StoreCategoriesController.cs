using Api.loja.Data;
using Dominio.loja.Entity;
using Dominio.loja.Interfaces.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NPOI.OpenXmlFormats;
using System.Net;

namespace Api.loja.Controllers.Admin
{
    [Route("api/Admin/Store/Categories/[action]")]
    [Authorize]
    public class StoreCategoriesController : BaseController
    {
        private readonly IAdminStoreCategoriesControllerContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public StoreCategoriesController(ILogger<BaseController> logger , StoreContext context , IWebHostEnvironment webHostEnvironment ) : base(logger)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutCategories(Categories dataSource)
        {
            try
            {
                _context.categories.Add(dataSource);
                _context.SaveChanges();
                return StatusCode((int)HttpStatusCode.Created , dataSource);

            }catch(Exception ex )
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCategories(Categories dataSource)
        {
            try
            {
                _context.categories.Remove(dataSource);
                _context.SaveChanges();
                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSubCategories(SubCategories dataSource)
        {
            try
            {
                _context.subCategories.Remove(dataSource);
                _context.SaveChanges();
                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSubSubCategories(SubSubCategories dataSource)
        {
            try
            {
                _context.subSubCategories.Remove(dataSource);
                _context.SaveChanges();
                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
