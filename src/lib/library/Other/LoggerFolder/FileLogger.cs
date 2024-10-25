using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* *********************************************************************************************************
 * File Logger
 * --------------
 * Defines additional behaviors that can be dynamically added to components. File Logger as concrete 
 * decorator, overrides the methods of the base logger decorator and execute their behaviour before or
 * after the parent method is called.
 * *********************************************************************************************************/

namespace library.Other.LoggerFolder {
    internal class FileLogger : BaseLogger {

        private string _filename;
        public FileLogger(ILogger logger, string fileName) : base(logger) {
            _filename = fileName;
        }

        public override void LogQuery(string query, Dictionary<string, object> queryParameters) {
            string parametersString;
            if (queryParameters != null) parametersString = ((ConcreteLogger)_logger).ReplacePlaceholders(query, queryParameters);
            else parametersString = query;

            try {
                File.AppendAllText(_filename, String.Concat(DateTime.Now, " - logged query : ", parametersString, "\n"));
            }
            catch(Exception e) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(String.Concat("Log error : ", e.Message));
                Console.ResetColor();
            }
        }
    }
}
