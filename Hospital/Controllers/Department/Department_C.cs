using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital.Models;
using System.Data.Odbc;
using Hospital.Controllers.DB;
using System.Data;

namespace Hospital.Controllers
{
    public class Department_C
    {
        public static Department DE_seekname(string id)
        {
            OdbcConnection sqlConnection1 = DBManager.GetOdbcConnection();
            sqlConnection1.Open();
            OdbcCommand odbcCommand = new OdbcCommand("select * from department where DE_ID='" + id + "'", sqlConnection1);
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
        public static List<Department> GetDepartmentName()
        {
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            string sql = "SELECT DE_Name FROM `hospital`.`department` ";
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader(CommandBehavior.CloseConnection);
            if (odbcDataReader.HasRows)
            {
                List<Department> list = Department.getList(odbcDataReader);
                odbcConnection.Close();
                return list;
            }
            odbcConnection.Close();
            return null;

        }
    }
}