using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital.Models;
using System.Data.Odbc;
using Hospital.Controllers.DB;

namespace Hospital.Controllers
{
    public class Department_C
    {
        public static Department DE_seekname(string id)
        {
            OdbcConnection sqlConnection1 = DBManager.GetOdbcConnection();
            sqlConnection1.Open();
            OdbcCommand odbcCommand = new OdbcCommand("select DE_Name from department where DE_ID='" + id + "'", sqlConnection1);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader();

            if (odbcDataReader.HasRows)
            {
                List<Department> list = Department.getList(odbcDataReader);
                sqlConnection1.Close();
                return list[0];
            }
            else
                sqlConnection1.Close();
            return null;
        }
    }
}