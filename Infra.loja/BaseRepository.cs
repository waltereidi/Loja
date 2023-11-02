
using Dominio.loja.Interfaces;

namespace Infra.loja.Interfaces
{
    
    public class BaseRepository
    {
        internal readonly IConnectionFactory ConnectionFactory;

        public BaseRepository(IConnectionFactory connectionFactory)
        {
            ConnectionFactory = connectionFactory;
        }
    }
}
