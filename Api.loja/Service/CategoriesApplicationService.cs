using Api.loja.Contracts;
using Api.loja.Data;
using Dominio.loja.Events.Praedicamenta;
using Framework.loja.Interfaces;
using System.Runtime.CompilerServices;

namespace Api.loja.Service
{
    public class PraedicamentaApplicationService : IApplicationService
    {
        public  Praedicamenta _praedicamenta;
        private readonly StoreContext _context;
        public PraedicamentaApplicationService(StoreContext context)
        {
            _context = context;
        }
        public async Task Handle<T>(T command) where T : class
        {
            switch (command)
            {
                case PraedicamentaContract.V1.AddCategories c : HandleCreateCategories(c);break;
                case PraedicamentaContract.V1.AddSubCategories c: HandleCreateSubCategories(c); break;
                case PraedicamentaContract.V1.AddSubSubCategories c: HandleCreateSubSubCategories(c); break;
                default:break;
            }
        }

        private void HandleCreateSubSubCategories(PraedicamentaContract.V1.AddSubSubCategories c)
        {
            
        }

        private void HandleCreateSubCategories(PraedicamentaContract.V1.AddSubCategories c)
        {
            throw new NotImplementedException();
        }

        private async Task HandleCreateCategories(PraedicamentaContract.V1.AddCategories c)
        {
            throw new NotImplementedException();
        }
    }
}
