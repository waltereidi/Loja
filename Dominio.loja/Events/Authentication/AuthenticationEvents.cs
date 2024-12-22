using Dominio.loja.Entity;
using System.Net;
using System.Net.NetworkInformation;

namespace Dominio.loja.Events.Authentication
{
    public static class AuthenticationEvents
    {
        /// <summary>
        /// These events come from application service layer
        /// </summary>
        public class Request()
        {
            /// <summary>
            /// Delivers all authentications attempt from the remoteIP and client found
            /// </summary>
            /// <param name="auth"></param>
            public record SetAuthentications(IEnumerable<Authentications>? auth);
            /// <summary>
            /// Refers to an authentication attempt without a login match
            /// </summary>
            /// <param name="login"></param>
            /// <param name="value"></param>
            public record SetClientNotFound(string login , int? value = null);
            /// <summary>
            /// This event indicates a wrong password authentication attempt 
            /// </summary>
            /// <param name="client"></param>
            /// <param name="value"></param>
            public record SetWrongPassword(Clients client ,int? value =null );
            /// <summary>
            /// Sets aggregate root client 
            /// </summary>
            /// <param name="client"></param>
            public record SetClient(Clients client);
            /// <summary>
            /// Refers to createIpScore Event in aggregate root
            /// </summary>
            public class CreateIpScore
            {
                public IPAddress ipAddress;
                public IPScore ipScore;
                public CreateIpScore(IPScore ip)
                {
                    ipAddress = ip.IpAddress;
                    ipScore = ip;
                }
                public CreateIpScore(IPAddress ip) => ipAddress = ip;

            }
        }
        public record AppendAuthMessage(string message, bool success);
        public record ChangeAuthMessage(string message, bool success);

        public record BlockIp(string description);

        /// <summary>
        /// Refers to create a new Instance of authentication event sent from aggregate root to entity
        /// </summary>
        /// <param name="ipScore"></param>
        /// <param name="client"></param>
        public record CreateAuthentications(IPScore ipScore, Clients client);

        /// <summary>
        /// Refers to a successfull authentication event
        /// </summary>
        public record SetSuccessfullAuthentication(Guid? ipScoreId = null );


        /// <summary>
        /// Refers to events to return to frontend application
        /// </summary>
        public class Response()
        {
            public record  LoginAdmin();
        }


    }
}
