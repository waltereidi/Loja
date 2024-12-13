using Dominio.loja.Entity;
using System.Net;
using System.Net.NetworkInformation;

namespace Dominio.loja.Events.Authentication
{
    public static class AuthenticationEvents
    {

        public class Request()
        {
            public record SetClient(Clients client );
            public record SetAuthentications(IEnumerable<Authentications>? auth);
            public record CreateIpScore(IPAddress? ipAddress , IPScore iPScore );
            public class CreateAuthentications(IPScore ipScore , Clients client);
        }
        public class Response()
        {
            public record  LoginAdmin();
        }
        
    }
}
