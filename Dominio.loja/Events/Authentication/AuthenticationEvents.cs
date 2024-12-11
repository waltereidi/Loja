using Dominio.loja.Entity;
using System.Net;

namespace Dominio.loja.Events.Authentication
{
    public static class AuthenticationEvents
    {
        public class Request()
        {
            public record class LoginAdmin(Clients client  , IPScore? IPScore , IEnumerable<Authentications>? auth , Context context);
            public class Context
            {
                public IPAddress Ip { get; private set; }
                public string Referer { get; private set; }
                public Context(IPAddress ip , string referer )
                {
                    Ip = ip ?? throw new ArgumentNullException(nameof(ip));
                    Referer = referer ?? throw new ArgumentNullException(nameof(referer));
                }
            }
            public record CreateIpScore(IPAddress ipAddress );
        }
        public class Response()
        {
            public record  LoginAdmin();
        }
        
    }
}
