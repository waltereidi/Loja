using Dominio.loja.Interfaces;
using System.Data;
using System.Data.SqlClient;


namespace Infra.loja
{
    public class SqlConnectionFactory : IConnectionFactory
    {
        private string ConnectionString { get; }

        public SqlConnectionFactory(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public IDbConnection openConnection()
        {
            var connection = new SqlConnection(ConnectionString);
            if (connection == null) throw new InvalidOperationException();

            connection.ConnectionString = ConnectionString;

            return connection;
        }
    }
}
