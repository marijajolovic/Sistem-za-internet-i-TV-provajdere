using System.Data;
using MySql.Data.MySqlClient; // // Potrebno instalirati: References -> Manage NuGet Packages -> Search: MySql.Data.MySqlClient

namespace library.Database {
    internal class ConnectionMySQL : IDatabaseConnection {

        public IDbConnection Connect(string connectionString) {
            return new MySqlConnection(connectionString);
        }

    }
}
