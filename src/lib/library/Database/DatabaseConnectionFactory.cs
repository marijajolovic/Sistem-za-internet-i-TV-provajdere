using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.Database {

    enum DatabaseType {
        MySQL, SQLite, NOTSUPPORTED
    }

    internal class DatabaseConnectionFactory {
        
        public static IDbConnection CreateDatabaseConnection(string connectionString) {
            DatabaseType type = recogniceDatabase(connectionString);
            IDatabaseConnection connection = null;

            switch(type) {
                case DatabaseType.MySQL:
                    connection = new ConnectionMySQL();
                    break;
                case DatabaseType.SQLite:
                    connection = new ConnectionSQLite();
                    break;
                case DatabaseType.NOTSUPPORTED:
                    connection = null;
                    break;
                default:
                    connection = null;
                    break;
            }

            if(connection == null) {
                throw new Exception("ERROR at DatabaseConnectionFactory.CreateDatabaseConnection - Not recognized connection string");
            }

            return connection.Connect(connectionString);
        }

        private static DatabaseType recogniceDatabase(string connectionString) {
            if (connectionString.Contains("server") && connectionString.Contains("database"))
                return DatabaseType.MySQL;

            if (connectionString.Contains("Data Source") || connectionString.Contains("DataSource"))
                return DatabaseType.SQLite;

            return DatabaseType.NOTSUPPORTED;
        }

    }
}
