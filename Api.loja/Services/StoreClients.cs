using Api.loja.Data;
using Dominio.loja.Dto.CustomEntities;
using Dominio.loja.Entity;

using System.Data.Entity.Infrastructure;

namespace Api.loja.Services
{
    public class StoreClients 
    {
        StoreContext _context; 
        public StoreClients() 
        {
            
        }
        public Clients GetEditMyProfile(int ID_Clients)
        {
            return null; 
        }
        public bool PutEditMyProfile(Clients dataSource)
        {
            return false;
        }

        public List<GetRequestOrdersDTO> GetOrdersRequest(int ID_Clients)
        {
            return null;
        }
        

    }
}
