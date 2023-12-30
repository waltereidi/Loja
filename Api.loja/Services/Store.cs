using Dominio.loja.Dto.CustomEntities;
using Dominio.loja.DTO.Requests;
using Dominio.loja.Entity;
using Dominio.loja.Interfaces.Context;
using Dominio.loja.Interfaces.Services;

namespace Api.loja.Services
{
    public class Store : IStore
    {
        IStoreContext _context; 
        public Store()
        {
            
        }

        public void getLogin(LoginRequest loginRequest)
        {
            //Clients client = _context.GetClient(loginRequest.Login, loginRequest.Password);
            //loginRequest.Clients = client;
            //var login = loginRequest.GetToken();

        }

    }
}
