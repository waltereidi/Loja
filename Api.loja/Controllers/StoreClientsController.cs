using Api.loja.Data;
using Api.loja.Services;
using Dominio.loja.Dto.CustomEntities;
using Dominio.loja.Dto.Requests;
using Dominio.loja.Interfaces;
using Dominio.loja.Interfaces.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.loja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreClientsController : BaseController
    {
        private readonly StoreClients _storeClients;
        public StoreClientsController(ILogger<StoreClientsController> logger  , StoreClients storeClients ) : base(logger)
        {
            _storeClients = new StoreClients();
        }
        [HttpPost]
        public IActionResult getOrdersRequest([FromBody] StoreClientsOrdersRequest request)
        {
            


            return Ok(storeClients.getPermissions());

        }
        [HttpGet]
        public IActionResult getTest()
        {
            return Ok(ClientsPermission.permissionsList);
        }


        // GET: StoreClientsController
     }
}
