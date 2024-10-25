using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* *********************************************************************************************************
 * Base Logger
 * --------------
 * Class that has a field for an encapsulated object reference. The field type should be declared as a
 * logger interface so that if can contain both concrete logger and decorators.
 * The base logger decorator delegates all operations to the encapsulated object.
 * *********************************************************************************************************/

namespace library.Other.LoggerFolder {
    internal class BaseLogger : ILogger{

        protected ILogger _logger;

        public BaseLogger(ILogger logger) {
            _logger = logger;   
        }

        public virtual void LogQuery(string query, Dictionary<string, object> queryParameters) {
            _logger.LogQuery(query, queryParameters);    
        }
    }
}
