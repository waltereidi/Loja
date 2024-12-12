using Dominio.loja.Entity;
using System.Net;

namespace Dominio.loja.Events.Authentication
{
    public static class AuthenticationEvents
    {
        public class SuccessfullAuthentication()
        {

        }
        public class Request()
        {
            public record SetClient(Clients client );
            public record SetAuthentications(IEnumerable<Authentications>? auth);
            public class Context
            {
                public string Referer { get; private set; }
                public Context(string referer )
                {
                    Referer = referer ?? throw new ArgumentNullException(nameof(referer));
                }
            }
            public record CreateIpScore(IPAddress? ipAddress , IPScore iPScore );
            public record CreateAuthentications(int client_id, int ipScore_id);
        }
        public class Response()
        {
            public record  LoginAdmin();
        }
        
    }
}
