using Dominio.loja.Events.Authentication;

namespace Dominio.loja.Interfaces
{
    public interface IAuthentication
    {
        
        bool ValidateAuthentication(Authentication @e);
    }
}
