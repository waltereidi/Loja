using Dominio.loja.Interfaces.Context;
using Microsoft.AspNetCore.Mvc;

namespace Api.loja.Controllers
{
    public class BaseController : Controller
    {
        private readonly ILogger<BaseController> _logger;
        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;

        }
    }
}
