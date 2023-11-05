using Dominio.loja.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.loja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreClientsController : Controller
    {
        private readonly ILogger<StoreClientsController> _logger;
        public StoreClientsController(ILogger<StoreClientsController> logger)
        {
            _logger = logger;

        }
        // GET: StoreClientsController
     }
}
