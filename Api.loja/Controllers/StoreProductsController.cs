
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
    public class StoreProductsController : ControllerBase
    {
        private readonly IStoreProductsContext _context; 
        private readonly ILogger<StoreProductsController> _logger;
        public StoreProductsController(ILogger<StoreProductsController> logger, IStoreProductsContext context )
        {
            _logger = logger;
            _context = context;

        }
        
        // GET: api/<ClientesController>
        [HttpGet]
        [Authorize]
        public List<Categories> Get()
        {
            var i = _context.GetCategory();
            var o = _context.Category.ToList();
            
            return i;
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClientesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
