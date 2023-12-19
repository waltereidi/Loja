using Dominio.loja.Dto.CustomEntities;
using Dominio.loja.Dto.Models;
using Dominio.loja.Dto.Requests;
using Dominio.loja.DTO.Requests;
using Dominio.loja.Entity;
using Dominio.loja.Interfaces.Context;
using Stripe;

namespace Api.loja.Services
{
    public class StoreClients
    {
        IStoreContext _storeContext; 
        public StoreClients() 
        {
            
        }
        public List<PermissionsRelation> getPermissions()
        {
            return ClientsPermission.permissionsList;
        }
        public ResponseModel<bool> DeleteCartProducts()
        {
            return new ResponseModel<bool>( false , "");
        }
        

    }
}
