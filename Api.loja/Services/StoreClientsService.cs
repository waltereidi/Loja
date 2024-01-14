using Api.loja.Data;
using Dominio.loja.Dto.CustomEntities;
using Dominio.loja.Entity;
using Dominio.loja.Interfaces.Context;

namespace Api.loja.Services
{
    public class StoreClientsService 
    {
        IStoreClientsControllerContext _context;
        public StoreClientsService(IStoreClientsControllerContext context) 
        {
            _context = context;
        }
        
        public Clients? GetEditMyProfile(int ID_Clients)
        {
            var i = _context.clients.First();
            return i;
        }
        public bool PutEditMyProfile(Clients dataSource)
        {
            return false;
        }

        public List<LoginResponse> GetOrdersRequest(int ID_Clients)
        {
            return null;
        }
        

    }
}
