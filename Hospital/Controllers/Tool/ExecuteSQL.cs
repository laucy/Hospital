using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Odbc;

namespace Hospital.Controllers.Tool
{
    public class ExecuteSQL
    {
        public static bool ExecuteNonQuerySQL_GetBool(string sql)
        {
            System.Diagnostics.Debug.WriteLine("sql:" + sql);
            OdbcConnection connection = DB.DBManager.GetOdbcConnection();
            connection.Open();
            OdbcCommand command = new OdbcCommand(sql, connection);


            int i = command.ExecuteNonQuery();
            connection.Close();
            return (i > 0) ? true : false;
        }

        public static int ExecuteNonQuerySQL_GetInt(string sql)
        {
            OdbcConnection connection = DB.DBManager.GetOdbcConnection();
            connection.Open();
            OdbcCommand command = new OdbcCommand(sql, connection);
            int i = command.ExecuteNonQuery();
            connection.Close();
            return i;
        }
        public static int ExecuteNonQuerySQL_GetResult(string sql)
        {
            OdbcConnection connection = DB.DBManager.GetOdbcConnection();
            connection.Open();
            OdbcCommand command = new OdbcCommand(sql, connection);
            Object obj = command.ExecuteScalar();
            connection.Close();
            return (obj == null) ? 0 : 1;
        }
    }
}