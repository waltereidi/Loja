using Api.loja.Data;
using Dominio.loja.Events.Authentication;
using Framework.loja.Interfaces;

namespace Api.loja.Service
{
    public class ProductManagerApplicationService : IApplicationService
    {
        private readonly StoreContext _context;
        public ProductManagerApplicationService(StoreContext context)
        {
            _context = context;
        }

        public async Task<object?> Handle(object command)
        {
            throw new NotImplementedException();
        }
    }
}
