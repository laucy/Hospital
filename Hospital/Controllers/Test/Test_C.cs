using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace Hospital.Controllers
{
    public class Test_C
    {
        //已知病人id查询检查项目和价格
        public static List<Test> SelectTest(int patientid)
        {
            string cid = Case_C.GetCaseID(patientid);
            string sql = "SELECT * FROM `hospital`.`test` WHERE `C_ID` = '" + cid + "'";
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            OdbcCommand odbcCommand= new OdbcCommand(sql, odbcConnection);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader(CommandBehavior.CloseConnection);
            if (odbcDataReader.HasRows)
            {
                List<Test> list = Test.getList(odbcDataReader);
                odbcConnection.Close();
                return list;
            }
            else
                odbcConnection.Close();
            return null;
        }
        public static bool AddTest(List<Test> tests)//属性E_ID传递进来，其他不用
        {
            foreach (Test test in tests)
            {
                string sql = "insert into `hospital`.`test` " +
                "values('" + test.IT_ID + "', '" + test.C_ID + "', '" + test.IT_Name + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "','" + test.IT_Price + "')";
                Tool.ExecuteSQL.ExecuteNonQuerySQL_GetBool(sql);
            }
            return true;
        }
    }
}