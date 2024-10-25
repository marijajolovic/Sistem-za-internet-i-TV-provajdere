using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* *********************************************************************************************************
 * Interface
 * *********************************************************************************************************/

namespace library.Other.LoggerFolder {
    internal interface ILogger {
        void LogQuery(string query, Dictionary<string, object> queryParameters);
    }
}
