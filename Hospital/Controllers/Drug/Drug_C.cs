using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Odbc;
using Hospital.Models;
namespace Hospital.Controllers
{
    public class Drug_C
    {
        public static List<Drug> SelectFuzzy(string info)
        {
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            string sql = "SELECT * FROM drug WHERE `D_Name` LIKE '%" + info + "%'";
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader(CommandBehavior.CloseConnection);

            if (odbcDataReader.HasRows)
            {
                List<Drug> list = Drug.getList(odbcDataReader);
                odbcConnection.Close();
                return list;
            }
            else
                odbcConnection.Close();
            return null;
        }
        //药品ID查药品单价
        public static float GetSellingPrice(int did)
        {
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            string sql = "SELECT D_SellingPrice FROM `hospital`.`drug` WHERE `D_ID`='" + did + "'";
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader reader = odbcCommand.ExecuteReader();
            if (reader.Read())
            {
                float D_SellingPrice = (float)reader[0];
                odbcConnection.Close();
                return D_SellingPrice;
            }
            odbcConnection.Close();
            return 0;
        }
        //药品ID查药品单价
        public static string GetDrugname(int did)
        {
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            string sql = "SELECT D_Name FROM `hospital`.`drug` WHERE `D_ID`='" + did + "'";
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader reader = odbcCommand.ExecuteReader();
            if (reader.Read())
            {
                string D_Name = reader[0].ToString();
                odbcConnection.Close();
                return D_Name;
            }
            odbcConnection.Close();
            return null;
        }
    }
}