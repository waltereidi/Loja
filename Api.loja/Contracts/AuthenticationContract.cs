namespace Api.loja.Contracts
{
    public static class AuthenticationContract
    {
        public record CookiesAuthentication();

        public static class V1 
        {
            public class Request
            {
                public record class LoginRequest(string email, string password);
                public record class LoginRequestContext(LoginRequest login, HttpContext context);
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