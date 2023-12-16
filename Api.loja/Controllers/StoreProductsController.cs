
using Api.loja.Data;
using Dominio.loja.Entity;
using Dominio.loja.Interfaces.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.loja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreProductsController : BaseController
    {
        public StoreProductsController(ILogger<StoreProductsController> logger) : base(logger)
        {

        }
        [HttpGet]
       public IActionResult GetNavBarCategories()
        {
            return Ok();
        }
        [HttpGet]
        public IActionResult GetBarCategories()
        {
            return Ok();
        }
        [HttpGet]
        public IActionResult GetPromotionCategoriesProducts()
        {
            return Ok();
        }
        [HttpGet]
        public IActionResult GetProduct(int id)
        {
            return Ok();
        }
        [HttpGet]
        public IActionResult GetProductsByCategories()
        {
            return Ok();
        }


    }
}
