using Dominio.loja.Entity;
using System.Net;
using System.Net.NetworkInformation;

namespace Dominio.loja.Events.Authentication
{
    public static class AuthenticationEvents
    {

        public class Request()
        {
            public record SetAuthentications(IEnumerable<Authentications>? auth);
            public class CreateIpScore
            {
                public IPAddress ipAddress;
                public IPScore ipScore;
                public CreateIpScore(IPScore ip)
                {
                    ipAddress = ip.IpAddress;
                    ipScore = ipScore; 
                }
                public CreateIpScore(IPAddress ip) => ipAddress = ip;

            }
            public class CreateAuthentications(IPScore ipScore , Clients client);
        }
        public class Response()
        {
            public record  LoginAdmin();
        }


    }
}
