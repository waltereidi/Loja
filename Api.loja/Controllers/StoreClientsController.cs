using Dominio.loja.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.loja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreClientsController : BaseController
    {
        public StoreClientsController(ILogger<StoreClientsController> logger) : base(logger)
        {

        }
        // GET: StoreClientsController
     }
}
