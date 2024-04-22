namespace Api.loja.Contracts
{
    public static class AuthenticationContract
    {
        public static class V1 {
            public record class LoginRequest(string Email,string Password);


        }
    }


}