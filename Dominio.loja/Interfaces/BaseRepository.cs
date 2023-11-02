using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Interfaces
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
