
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
            return Ok(_context.categories.Any() ? _context.categories.OrderBy(o=> o.Name).ToList() : null );
        }
        [HttpGet]
        public async Task<IActionResult> GetBarCategories()
        {
            return Ok(_context.categories.Any() ? _context.categories.OrderBy(o=> o.Name).ToList() : null );
        }
        [HttpGet]
        public async Task<IActionResult> GetPromotionCategoriesProducts()
        {
            return Ok( _context.categoriesPromotion.Any() ? 
                       _context.categoriesPromotion
                       .OrderBy(o=>  o.Categories.Name )
                       .OrderBy(o=> o.ProductsCategories).ToList() : null );
        }
        [HttpGet]
        public async Task<IActionResult> GetProduct(int id)
        {
            return Ok( _context.products.Any(x => x.ProductsId == id) ? _context.products.Single(x => x.ProductsId == id) : null ) ;
        }

    }
}
