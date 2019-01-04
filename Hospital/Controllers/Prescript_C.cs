using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace Hospital.Controllers
{
    public class Prescript_C
    {
        //已知病人id查询药方信息
        public static List<Prescript> SelectPrescript(int patientid)
        {
            string cid = Case_C.GetCaseID(patientid);
            string sql = "SELECT * FROM `hospital`.`prescript` WHERE `C_ID` = '" + cid + "'";
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader(CommandBehavior.CloseConnection);
            if (odbcDataReader.HasRows)
            {
                List<Prescript> list = Prescript.getList(odbcDataReader);
                odbcConnection.Close();
                return list;
            }
            else
                odbcConnection.Close();
            return null;
        }
        public static bool AddPrescript(List<Prescript> prescripts)//order属性E_ID传递进来，其他不用
        {
            foreach (Prescript prescript in prescripts)
            {
                string sql = "insert into `hospital`.`prescript` " +
                "values('" + prescript.D_ID + "', '" + prescript.C_ID + "', '" + prescript.D_Name + "','" + prescript.D_Number + "','" + prescript.D_Totalprice + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "','" + prescript.P_Notes + "')";
                Tool.ExecuteSQL.ExecuteNonQuerySQL_GetBool(sql);
            }
            return true;
        }
    }
    
}