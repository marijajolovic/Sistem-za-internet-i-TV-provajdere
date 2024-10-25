using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* *********************************************************************************************************
 * Concrete Logger
 * -----------------
 * Class of objects that are later encapsulated and extended. Defines basic behavior that can be modified
 * by decorators.
 * *********************************************************************************************************/


namespace library.Other.LoggerFolder {
    internal class ConcreteLogger : ILogger {

        private readonly string fileName = "../.. / .. / .. / .. / .. / log.txt";

        public void LogQuery(string query, Dictionary<string, object> queryParameters) {
            string logMessage;

            if (queryParameters != null) logMessage = String.Concat(DateTime.Now, " - executed query : ", ReplacePlaceholders(query, queryParameters), "\n");
            else logMessage = String.Concat(DateTime.Now, " - executed query : ", query, "\n");

            try {
                using (StreamWriter sw = File.AppendText(fileName)) {
                    sw.WriteLine(logMessage);
                }
            }
            catch (Exception e) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(String.Concat("Log error : ", e.Message));
                Console.ResetColor();
            }
        }

        internal string ReplacePlaceholders(string query, Dictionary<string, object> queryParameters) {

            string replacedQuery = query;

            foreach (var parameter in queryParameters) {

                string parameterName = parameter.Key;
                string parameterValue = parameter.Value?.ToString() ?? "";

                replacedQuery = replacedQuery.Replace(parameterName, parameterValue);
            }
                
            return replacedQuery;
        }

    }
}
