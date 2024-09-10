using Api.loja.Data;
using Dominio.loja.Events.FileUpload;
using Framework.loja.Interfaces;
using Integrations;
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
            V1.Requests.GetUsuarios cmd => GetUsers(cmd),
            _ => throw new InvalidOperationException("")
        };

        private object? GetUsers(V1.Requests.GetUsuarios cmd)
        {
            throw new NotImplementedException();
        }
    }
}
