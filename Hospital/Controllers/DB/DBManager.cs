using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;

namespace Hospital.Controllers.DB
{
    public class DBManager
    {
        public static OdbcConnection GetOdbcConnection()
        {
            return new OdbcConnection("Dsn=mysql;uid=root;pwd=lx123");
        }
    }
}