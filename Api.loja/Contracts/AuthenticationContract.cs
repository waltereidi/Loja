namespace Api.loja.Contracts
{
    public static class AuthenticationContract
    {
        public record CookiesAuthentication();

        public static class V1 
        {
            public class Request
            {
                public record GetUserInfo(HttpContext context);
                
                public record LoginRequest(string email, string password);
                public record LoginRequestContext(LoginRequest login, HttpContext context);
            }
            public class Responses
            {
                public record LoginResponse(JwtToken token,ClientInfo info );

            }
            public record ClientInfo(string firstName, string lastName, string nameInitials , JwtToken token);
            public record JwtToken(string serializedToken , DateTime createdAt , DateTime? expiresAt );
        }
    }
    

}