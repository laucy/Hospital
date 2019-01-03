using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace Hospital.Controllers.Doctor
{
    public class Case_C
    {
        //增
        public static bool Insert(int pid, int eid, string ccomplain, string cdiagnose,string cadvice)
        {
            string sql = "insert into `hospital`.`case` ( `P_ID`, `E_ID`,`C_Complain`, `C_Diagnose`, `C_Advice`) " +
                "values('" + Convert.ToInt32(pid) + "', '" + Convert.ToInt32(eid) + "'" +
                ",'" + ccomplain + "','" + cdiagnose + "','" + cadvice + "')";
            return Tool.ExecuteSQL.ExecuteNonQuerySQL_GetBool(sql);
        }
        //根据病人id查询病历id
        public static List<Case> SelectCID(string patientid)
        {
            string sql = "SELECT * FROM  `case` WHERE `P_ID`='"+patientid+"'";
            OdbcConnection odbcConnection =DB. DBManager.GetOdbcConnection();
            odbcConnection.Open();
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader(CommandBehavior.CloseConnection);
            if (odbcDataReader.HasRows)
            {
                List<Case> list = Case.getList(odbcDataReader);
                odbcConnection.Close();
                return list;
            }
            else
                odbcConnection.Close();
            return null;
        }
    }
}