
using Api.loja.Data;
using Dominio.loja.Entity;
using Dominio.loja.Interfaces.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace Api.loja.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class StoreProductsController : BaseController
    {
        IStoreProductsControllerContext _context;
        public StoreProductsController(ILogger<StoreProductsController> logger , StoreContext context) : base(logger)
        {
            _context = context; 
        }
        [HttpGet]
        public async Task<IActionResult> GetNavBarCategories()
        {
            
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetBarCategories()
        {
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetPromotionCategoriesProducts()
        {
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetProduct(int id)
        {
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetProductsByCategories()
        {
            return Ok();
        }


    }
}
