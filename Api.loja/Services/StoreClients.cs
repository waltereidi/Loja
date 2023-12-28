using Dominio.loja.Dto.CustomEntities;
using Dominio.loja.Dto.Models;
using Dominio.loja.Entity;
using Dominio.loja.Interfaces.Context;
using Dominio.loja.Interfaces.Services;
using Infra.loja.Data;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;

namespace Api.loja.Services
{
    public class StoreClients 
    {
        StoreClientsContext _context; 
        public StoreClients() 
        {
            
        }
        public Clients GetEditMyProfile(int ID_Clients)
        {
            var clients = _context.clients.Where(x => x.ID_Clients == ID_Clients);
            return clients.Any() ? clients.First() : null; 

        }
        public bool PutEditMyProfile(Clients dataSource)
        {
            try
            {
                _context.clients.Update(dataSource);
                _context.SaveChanges();    

                return true;
            }
            catch(DbUpdateException ex) 
            {
                return false; 
            }

        }

        public List<RequestOrdersClientsProductsCart> GetOrdersRequest(int ID_Clients)
        {

            GetRequestOrdersDTO
        }
        

    }
}
