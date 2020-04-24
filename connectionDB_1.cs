using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
 
namespace Tutorial.SqlConn
{
    class DBUtils
    {
 
        public static OracleConnection GetDBConnection()
        {
            string host = "192.168.0.102";
            int port = 1521;
            string sid = "db12c";
            string user = "simplehr";
            string password = "12345";
 
            return DBOracleUtils.GetDBConnection(host, port, sid, user, password);
        }
    }
 
}
