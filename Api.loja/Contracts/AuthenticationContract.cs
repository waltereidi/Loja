
namespace Api.loja.Contracts
{
    public static class AuthenticationContract
    {
        public record CookiesAuthentication();

        public static class V1
        {
            public enum ReCaptcha 
            { 
                GoogleReCaptchaV2 = 0 , 
                GoogleReCaptchaV3 = 1 ,
            }

            public class Request
            {
                public record GetUserInfo(HttpContext context);
                
                public record LoginRequest(string email, string password , string reCaptchaToken , ReCaptcha reCaptchaId);
                public record LoginRequestContext(LoginRequest login, HttpContext context);
                public class GoogleReCaptcha
                {
                    public record v2(string secret , string response ,string remoteip);
                }
            }
            public class Responses
            {
                public record LoginResponse(JwtToken token,ClientInfo info);
                public class GoogleReCaptcha 
                { 
                    public record V3_Verify(bool success 
                        ,DateTime? challenge_ts 
                        ,string apk_package_name
                        ,decimal score
                        ,string hostname );
                }

            }
            public record ClientInfo(string firstName, string lastName, string nameInitials , JwtToken token);
            public record JwtToken(string serializedToken , DateTime createdAt , DateTime? expiresAt );
        }
    }
    

}