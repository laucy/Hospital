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
        //根据病人名字查找病人id
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
        //返回单条病人信息
        public static Patient GetSingle_pInfo(string pid)
        {
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            string sql = "select * from patient where P_ID='" + Convert.ToInt32(pid) + "'";
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader();
            if (odbcDataReader.HasRows)
            {
                List<Patient> list = Patient.getList(odbcDataReader);
                odbcConnection.Close();
                return list[0];
            }
            odbcConnection.Close();
            return null;
        }
        //病床编号->病例ID(hospitalization)->病人ID(case)->病人信息
        public static Patient GetpInfo_bybed(string sid)
        {
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            string sql = "select * from hospitalization where S_ID='" + sid + "'";
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader();
            if (odbcDataReader.HasRows)
            {
                List<Hospitalization> list = Hospitalization.getList(odbcDataReader);
                Hospitalization hospitalization = list[0];
                sql = "select * from ccase where C_ID='" + hospitalization.C_ID + "'";
                odbcCommand = new OdbcCommand(sql, odbcConnection);
                odbcDataReader = odbcCommand.ExecuteReader();
                if(odbcDataReader.HasRows)
                {
                    List<Case> ca = Case.getList(odbcDataReader);
                    Case c = ca[0];
                    return Patient_C.GetSingle_pInfo(c.P_ID.ToString());
                }
                odbcConnection.Close();
                return null;
            }
            odbcConnection.Close();
            return null;
        }
        public static bool isExit(String pid)
        {
            string sql = "select *from patient where P_ID='" + Convert.ToInt32(pid) + "'";
            return Tool.ExecuteSQL.ExecuteNonQuerySQL_GetBool(sql);
        }
    }
}