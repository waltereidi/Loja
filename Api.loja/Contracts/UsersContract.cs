
namespace Api.loja.Contracts
{
    public class UsersContract
    {
        public class V1
        {
            public class Requests
            {
                public record GetUsuariosById(int id);

                public record GetUsuarios(int pagination , int amount);
                public record AddUsuario(int? id);
                public record DeleteUsuario(int id, string reason);
                public record UpdateUsuario(int id
                    , string email
                    , string password
                    , string firstName
                    , string lastName
                    , string address
                    , string phoneNumber
                    );
                public record UpdateUserPermission(
                    int userId

                    );
            }
            public class Responses
            {
                public record class Clients(int? id
                    , string firstName
                    , string lastName
                    , string email
                    , string address
                    , DateTime? updated_at
                    , DateTime created_at);
                
            }


        }
    }
}
