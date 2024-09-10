namespace Api.ServicesManager.Contracts
{
    public class UsersContract
    {
        public class V1
        {
            public record GetUsuarios(int? id);
            public record AddUsuario();
            public record DeleteUsuario(int id , string reason );
            public record UpdateUsuario(int id 
                ,string email 
                ,string password
                ,string firstName
                ,string lastName
                ,string address
                ,string phoneNumber
                );
            public record UpdateUserPermission(
                int userId

                );
        }
    }
}
