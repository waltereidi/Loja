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
            public record BlockIp();
            public record ChangeAuthMessage(string message , bool success );
            public record AppendAuthMessage(string message, bool success);
            public record SetClientNotFound(string login , int? value = null);
            public record SetWrongPassword(Clients client , int? value =null );
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
            public record CreateAuthentications(IPScore ipScore , Clients client);
            public record SetOutOfCommercialTimeMultipleAccountAttempt();
        }
        public class Response()
        {
            public record  LoginAdmin();
        }


    }
}
