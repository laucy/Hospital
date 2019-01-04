using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Odbc;
using Hospital.Models;

namespace Hospital.Controllers
{
    public class Case_C
    {
        //增
        public static bool Insert(int pid, int eid, string ccomplain, string cdiagnose,string cadvice,string hflag)
        {
            string sql = "insert into `hospital`.`case` ( `P_ID`, `E_ID`,`C_Complain`, `C_Diagnose`, `C_Advice`,`H_Flag`) " +
                "values('" + Convert.ToInt32(pid) + "', '" + Convert.ToInt32(eid) + "'" +
                ",'" + ccomplain + "','" + cdiagnose + "','" + cadvice + "','" + hflag + "')";
            return Tool.ExecuteSQL.ExecuteNonQuerySQL_GetBool(sql);
        }
        //根据病人ID查找病历ID
        public static string GetCaseID(int pid)
        {
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            string sql = "SELECT C_ID FROM `hospital`.`case` WHERE `P_ID`='"+pid+"'";
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader reader = odbcCommand.ExecuteReader();
            if (reader.Read())
            {
                string c_id = reader[0].ToString();
                odbcConnection.Close();
                return c_id;
            }
            odbcConnection.Close();
            return null;
        }
        //根据ID补充病历表
        public static bool UpdateCase(int P_ID,string C_Complain,string C_Diagnose,string C_Advice,string H_Flag)
        {
            string sql = "update `hospital`.`case` set `C_Complain`='" + C_Complain + "',`C_Diagnose`='" + C_Diagnose + "',`C_Advice`='" + C_Advice + "',`H_Flag`='" + H_Flag + "' where `P_ID`='" + P_ID+ "'";
            return Tool.ExecuteSQL.ExecuteNonQuerySQL_GetBool(sql);
        }
    }  
}