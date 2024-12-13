using Dominio.loja.Interfaces;


namespace Dominio.loja.Events.Authentication
{
    public class AuthenticationAdmin : IAuthentication
    {

        public bool ValidateAuthentication(Authentication e)
        {
            if(e._Client == null)
            {
                return false;
            }
            return false;

        }
    }
}
