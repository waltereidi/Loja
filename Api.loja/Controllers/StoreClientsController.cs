using Api.loja.Data;
using Api.loja.Services;
using Dominio.loja.Dto.Models;
using Dominio.loja.Dto.Requests;
using Dominio.loja.Entity;
using Dominio.loja.Interfaces.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Core;
using System.Net;
using System.Threading.Channels;
using NuGet.Protocol;
using System.Text;

namespace Api.loja.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class StoreClientsController : BaseController
    {
        private readonly StoreClientsService _service;
        private readonly IStoreClientsControllerContext _context;
        private const string QUEUE_NAME = "clients";
        public StoreClientsController(ILogger<StoreClientsController> logger , StoreContext context  ) : base(logger)
        {
            _context = context;
            _service = new StoreClientsService(context );
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEditMyProfile([FromHeader]int ID_Clients )
        {
           if(_context.clients.Any(x => x.ClientsId == ID_Clients))
            {
                Clients clients = _context.clients
                    .Select(s=> new Clients {
                        ClientsId = s.ClientsId,
                        Password = s.Password,
                    })
                    .First(x => x.ClientsId == ID_Clients);
                
                return Ok(new ResponseModel(true, clients));
            }
            return NotFound();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutEditMyProfile([FromBody] Clients dataSource)
        {
            try
            {
                if (_context.clients.Any(x => x.ClientsId == dataSource.ClientsId))
                {
                    _context.clients.Update(dataSource);
                    _context.SaveChanges();
                    return Ok();
                }
            }
            catch(UpdateException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);    
            }
            
            return NotFound();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOrdersRequest([FromHeader] int ID_Clients )
        {
            if(_context.clientsProducts_cart.Any(x=> x.ClientsId == ID_Clients ))
            {
                List<ClientsProductsCart> productsCart = _context.clientsProducts_cart.Where(x => x.ClientsId == ID_Clients).ToList();

                return Ok(new ResponseModel(true,productsCart));
            }
            return NotFound();
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        
        public async Task<IActionResult> PostOrdersRequest([FromBody]PostRequestOrdersRequest dataSource )
        {
            if (_context.clients.Any(x=> x.ClientsId == dataSource.ClientsId))
            {
                try
                {
                    var request = new RequestOrders { 
                        ClientsId = dataSource.ClientsId ,
                        Description = dataSource.Description,
                        Created_at = DateTime.Now
                    };

                    var createdRequest =_context.requestOrders.Add(request);
                    dataSource.CartProducts.ForEach(f=>
                    {
                        RequestOrdersProducts requestOrdersProducts = new RequestOrdersProducts()
                        {
                            Created_at = DateTime.Now , 
                            ProductsId = f.ProductsId,
                            Quantity = f.Quantity,
                            RequestOrdersId = createdRequest.Entity.ClientsId
                        };
                        _context.requestOrdersProducts.Add(requestOrdersProducts);
                    });

                    return Ok(new ResponseModel(true , _context.SaveChanges()));
                }
                catch(Exception ex)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            return StatusCode((int)HttpStatusCode.NotAcceptable);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutCartProducts(PutCartProductsRequest request)
        {
            if(_context.clients.Any(x=>x.ClientsId == request.ClientsId) && _context.products.Any(x=> x.ProductsId == request.ProductsId))
            {
                var cartProducts = new ClientsProductsCart()
                {
                    ClientsId = request.ClientsId, 
                    ProductsId = request.ProductsId,
                    IsActive=true , 
                    Quantity = request.Quantity,
                    Created_at = DateTime.Now,
                };
                try
                {
                    _context.clientsProducts_cart.Add(cartProducts);
                    return Ok(new ResponseModel(_context.SaveChanges()));
                }
                catch(Exception ex)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
                }
                
            }
            return NotFound();
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCartProducts(int CartProductsId)
        {
            if(_context.clientsProducts_cart.Any(x=>CartProductsId==x.ClientsProductsCartId))
            {
                var entity = _context.clientsProducts_cart.Find(CartProductsId);
                _context.clientsProducts_cart.Remove(entity);
                return Ok(new ResponseModel(_context.SaveChanges()));
            }
            return NotFound();
            
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCartProducts(int ClientsId)
        {
            if( _context.clients.Any(x=>x.ClientsId==ClientsId) )
            {
                var clientsCartProducts = _context.clients.Where(x=>x.ClientsId==ClientsId).Select(s => s.ClientsProductsCart);
                return Ok( new ResponseModel(true  , clientsCartProducts));
            }
            return NotFound();
        }

     }
}
