using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2F.Util.ADO
{
    public class DbConnection
    {
        public static string sConnectionString = "Server=123.31.12.46;Database=A2F.Dev;UID=a2f;PWD=X2JX69DAdiELLGcO";

        public SqlConnection oConn = new SqlConnection(sConnectionString);
        public void Open()
        {
            oConn.Open();
        }
        public void Close()
        {
            oConn.Close();
        }
    }
}
