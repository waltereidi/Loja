using Api.loja.Data;
using Dominio.loja.Dto.CustomEntities;
using Dominio.loja.Dto.Requests.AdminControllerRequests;
using Dominio.loja.Interfaces.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Net;
namespace Api.loja.Controllers.Admin
{
    [Route("api/Admin/[action]")]
    [ApiController]
    public class AdminController : BaseController
    {
        private readonly IAdminControllerContext _context;
        private readonly IConfiguration _configuration;
        public AdminController(ILogger<AdminController> logger, StoreContext context , IConfiguration configuration) : base(logger)
        {
            _context = context;
            _configuration = configuration;
        }
    
         
        
    }
}