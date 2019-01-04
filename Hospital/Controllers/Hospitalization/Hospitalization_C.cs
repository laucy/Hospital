using Hospital.Controllers.Tool;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace Hospital.Controllers
{
    public class Hospitalization_C
    {

        //已知病人id查询住院信息
        public static List<Hospitalization> SelectHospitalization(int patientid)
        {
            string cid = Case_C.GetCaseID(patientid);
            string sql = "SELECT * FROM `hospital`.`hospitalization` WHERE `C_ID` = '" + cid + "'";
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader(CommandBehavior.CloseConnection);
            if (odbcDataReader.HasRows)
            {
                List<Hospitalization> list = Hospitalization.getList(odbcDataReader);
                odbcConnection.Close();
                return list;
            }
            else
                odbcConnection.Close();
            return null;
        }
        //修改出院日期
        public static bool AlterHospitalization(int patientid)
        {
            string cid = Case_C.GetCaseID(patientid);
            DateTime hout = DateTime.Now;
            float hsum = 0;
            List<Hospitalization> hospitalizations = SelectHospitalization(patientid);
            if (hospitalizations != null)
            {
                int days = (hout - hospitalizations[0].H_In).Days;
                hsum = days * 50;
            }    
            string sql = "UPDATE `hospital`.`hospitalization`"
                + "SET `H_Out`='" + hout + "', `H_Sum`='" + hsum + "'WHERE `C_ID`='" + cid + "'";
            return ExecuteSQL.ExecuteNonQuerySQL_GetBool(sql);            

        } 
    }
}