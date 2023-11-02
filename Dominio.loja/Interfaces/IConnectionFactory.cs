
using System.Data;


namespace Dominio.loja.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection openConnection();
        
    }
}
