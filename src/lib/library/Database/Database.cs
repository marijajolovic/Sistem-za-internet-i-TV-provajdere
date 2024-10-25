using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using library.Other;
using library.Other.LoggerFolder;

namespace library.Database {

    public sealed class Database {

        private static Database Instance = null;
        private IDbConnection connection = null;
        private static readonly object _lock = new object(); // lock object that will be used to synchronize threads
        private string configFilepath = "../../../../../config.txt";

        private ILogger _logger = null;
        private string _fileName = "../../../../../log.txt";

        /* *********************************************************************************************************
         * Private Constructor
         * -------------------
         * Private constructor to prevent other objects from using the new() operator
         * ********************************************************************************************************* */
        private Database() {
            if(connection != null && connection.State == ConnectionState.Open) {
                connection.Close();
            }

            ILogger concreteLogger = new ConcreteLogger();
            _logger = new FileLogger(concreteLogger, _fileName);

            try {
                string connectionString = TextParser.Parse(configFilepath)["CONNSTRING"];
                connection = DatabaseConnectionFactory.CreateDatabaseConnection(connectionString);
                connection.Open();
            }
            catch(Exception ex) {
                Console.Write(ex.Message);
            }

        }

        /* *********************************************************************************************************
         * Get instance method
         * -------------------
         * ********************************************************************************************************* */
        public static Database GetInstance() {
            if (Instance == null) {
                lock (_lock) {
                    if (Instance == null) {
                        Instance = new Database();
                    }
                }
            }
            return Instance;
        }

        /* *********************************************************************************************************
         * Query
         * -------------------
         * ********************************************************************************************************* */
        public DataTable Query(string sql, Dictionary<string, object> queryParameters) {
            DataTable dt = new DataTable();
            IDbCommand command = connection.CreateCommand();
            command.CommandText = sql;

            // Add parameters to the command
            foreach (var param in queryParameters) {
                IDbDataParameter parameter = command.CreateParameter();
                parameter.ParameterName = param.Key;
                parameter.Value = param.Value;
                command.Parameters.Add(parameter);
            }

            // Execute the SQL query and fill the DataTable with the results
            using (IDataReader reader = command.ExecuteReader()) {
                dt.Load(reader);
            }

            _logger.LogQuery(sql, queryParameters);

            return dt;
        }

    }
}
