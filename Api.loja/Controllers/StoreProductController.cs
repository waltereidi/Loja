
using Dominio.loja.Entity;
using Dominio.loja.Interfaces;
using Dominio.loja.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.loja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context; 
        private readonly ILogger<StoreProductController> _logger;
        public StoreProductController(ILogger<StoreProductController> logger, ApplicationDbContext context )
        {
            _logger = logger;
            _context = context;

        }
        

        // GET: api/<ClientesController>
        [HttpGet]
        public List<Category> Get()
        {
            var i = _context.Category.Where(b => b.Id == 1).First();
            var u = _context.Category.Where(b => b.Id == 0).ToList();
            var x = _context.Products.Select(s => s.Name );
            var price = _context.Prices.ToList();

            var entryPoint = (from p in _context.Products
                              join c in _context.Category on p.Category_Id equals c.Id
                              join pr in _context.Prices on p.Price_id equals pr.Id
                              select new
                              {
                                  p.Id
                              });
            i.Id = null;
            
            var r = _context.Category.Add(i);
            _context.SaveChanges();
            var s = entryPoint.Where(x=> x.Id==1).ToList();

            return u;
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
