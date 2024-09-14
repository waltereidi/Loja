using Api.loja.Data;
using Framework.loja.Interfaces;
using static Api.loja.Contracts.UsersContract;


namespace Api.loja.Service
{
    public class UsersApplicationServices : IApplicationService
    {
        private readonly StoreContext _context;
        private readonly IConfiguration _configuration;
        public UsersApplicationServices(IConfiguration configuration, StoreContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<object?> Handle(object command) => command switch
        {
            V1.Requests.GetUsuariosById cmd => GetUsers(cmd),
            _ => throw new InvalidOperationException("")
        };

        private V1.Responses.Clients GetUsers(V1.Requests.GetUsuariosById cmd)
        {
            if (!_context.clients.Any())
                throw new Exception();

            var client = _context.clients.First(x => x.Id == cmd.id);
            V1.Responses.Clients result = new(client.Id
                , client.FirstName
                , client.LastName
                , client.Email
                , client.Address
                , client.Updated_at
                , client.Created_at );
            return result;
        }
 
    }
}
