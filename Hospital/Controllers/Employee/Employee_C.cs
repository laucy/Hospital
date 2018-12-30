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
    public class Employee_C
    {
        public static List<Employee> SelectFuzzy(string info)
        {
            string sql = "SELECT * FROM employee "
                + "WHERE `E_ID` LIKE '%" + info + "%'"
                + "OR `E_Name` LIKE '%" + info + "%'"
                + "OR `E_Sex` LIKE '%" + info + "%'"
                + "OR `E_Phone` LIKE '%" + info + "%'"
                + "OR `E_Position` LIKE '%" + info + "%'";
            OdbcConnection odbcConnection = DBManager.GetOdbcConnection();
            odbcConnection.Open();
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader(CommandBehavior.CloseConnection);
            if (odbcDataReader.HasRows)
            {
                List<Employee> list = Employee.getList(odbcDataReader);
                odbcConnection.Close();
                return list;
            }
            else
                odbcConnection.Close();
            return null;
        }
    }
}