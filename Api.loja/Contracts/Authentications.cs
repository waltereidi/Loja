namespace Authentication.Contracts
{
    public static class Authentication
    {
        public static class V1{
            public class LoginRequest{
                public string Email {get;set;}
                public string Password {get;set;}
            }

        }
    }


}