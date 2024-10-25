using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.Database {
    internal interface IDatabaseConnection {
        IDbConnection Connect(string connectionString);
    }
}
