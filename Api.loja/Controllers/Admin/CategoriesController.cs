using Api.loja.Contracts;
using Api.loja.Service;
using Dominio.loja.Entity;
using Dominio.loja.Events.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Api.loja.Contracts.PraedicamentaContract;


namespace Api.loja.Controllers.Admin
{
    [Route("api/Admin/Categories/[action]")]
    [Authorize]
    [ApiController]
    public class CategoriesController : BaseController
    {
        private readonly PraedicamentaApplicationService _service;
        public CategoriesController(ILogger<CategoriesController> logger , PraedicamentaApplicationService service) : base(logger)
        {
            _service = service;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<IActionResult> AddCategories(V1.Requests.AddCategories category) => HandleRequest(category, _service.Handle);

        [HttpGet]
        [ProducesResponseType<Categories>(StatusCodes.Status200OK)]
        public  Task<IActionResult> GetCategoryById(int id) => HandleRequest(new V1.Requests.GetCategoriyById(id), _service.Handle);

        [HttpGet]
        [ProducesResponseType<SubCategories>(StatusCodes.Status200OK)]
        public  Task<IActionResult> GetSubCategoryById(int id) => HandleRequest(new V1.Requests.GetSubCategoryById(id), _service.Handle);

        [HttpGet]
        [ProducesResponseType<SubSubCategories>(StatusCodes.Status200OK)]
        public  Task<IActionResult> GetSubSubCategoryById(int id) => HandleRequest(new V1.Requests.GetSubSubCategoryById(id), _service.Handle);
        [HttpGet]
        [ProducesResponseType<IEnumerable<Categories>>(StatusCodes.Status200OK)]
        public  Task<IActionResult> GetAllCategories() => HandleRequest(new V1.Requests.GetAllCategories() ,  _service.Handle);

        
    }
}