using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection openConnection();
        
    }
}
