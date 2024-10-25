using System.Data;
using System.Data.SQLite;   // Potrebno instalirati: References -> Manage NuGet Packages -> Search: System.Data.SQLite

namespace library.Database {
    internal class ConnectionSQLite : IDatabaseConnection {
        public IDbConnection Connect(string connectionString) {
            return new SQLiteConnection(connectionString);
        }
    }
}
