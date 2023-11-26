using Dominio.loja.Dto.CustomEntities;
using Dominio.loja.DTO.Requests;

namespace Dominio.loja.Interfaces.Services
{
    public interface IStore
    {
        ClientsPermission getLogin(LoginRequest loginRequest);
    }
}
