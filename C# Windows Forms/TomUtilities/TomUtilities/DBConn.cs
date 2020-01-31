using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomUtilities
{
    public class DBConn
    {
        public static SqlConnection GetConnection(string conn)
        {
            
            return new SqlConnection(conn);

        }
    }
}
