using MySql.Data.MySqlClient;   // behold denne hvis du bruker MySql.Data
// using MySqlConnector;        // bruk denne hvis du heller har MySqlConnector-pakken
using Microsoft.Extensions.Configuration;

namespace FirstWebApplication.Data
{
    public class DapperContext
    {
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' mangler.");
        }

        // ⬇️ Returner MySqlConnection (ikke IDbConnection)
        public MySqlConnection CreateConnection()
            => new MySqlConnection(_connectionString);
    }
}
