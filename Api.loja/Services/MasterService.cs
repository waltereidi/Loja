using Dominio.loja.Dto.CustomEntities;
using Dominio.loja.Dto.Requests;
using Dominio.loja.Entity;
using Dominio.loja.Interfaces.Context;

namespace Api.loja.Services
{
    public class MasterService
    {
        
        public IStoreContext _storeContext;
        public MasterService(MasterRequest request )
        {
            ClientsPermission.permissionsList  = _storeContext.GetPermissionsRelation(request.Email);
        }
    }
}
