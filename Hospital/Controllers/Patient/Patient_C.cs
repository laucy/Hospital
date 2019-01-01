using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Odbc;
using Hospital.Models;
namespace Hospital.Controllers
{
    public class Patient_C
    {
        //增
        public static bool Insert(string pname, string psex, string page, string pphone)
        {
            string sql = "insert into `hospital`.`patient` (`P_Name`, `P_Sex`, `P_Age`,`P_Phone`) " +
                "values('" + pname + "', '" + psex + "', '" + Convert.ToInt32(page) + "','" + pphone + "')";
            return Tool.ExecuteSQL.ExecuteNonQuerySQL_GetBool(sql);
        }
        //查找
        public static string GetPatientid(string pname)
        {
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            string sql = "SELECT P_ID FROM `hospital`.`patient` WHERE `P_NAME`='" + pname + "'";
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader reader = odbcCommand.ExecuteReader();
            if (reader.Read())
            {
                string patientid = reader[0].ToString();
                odbcConnection.Close();
                return patientid;

            }
            odbcConnection.Close();
            return null;

        }
        public static List<Patient> GetPatientinformation(string pid)
        {
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            string sql = "select *from patient where P_ID='" + Convert.ToInt32(pid) + "'";
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader();
            if (odbcDataReader.HasRows)
            {
                List<Patient> list = Patient.getList(odbcDataReader);
                odbcConnection.Close();
                return list;
            }
            odbcConnection.Close();
            return null;
        }
    }
}