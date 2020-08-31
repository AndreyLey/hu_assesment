using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Form_Builder.DB
{
    public class DbConnectionString
    {
        public string DbPort { get; set; }
        public string DbHost { get; set; }

        public DbConnectionString(string host, string port)
        {
            DbPort = port;
            DbHost = host;
        }
    }
}
