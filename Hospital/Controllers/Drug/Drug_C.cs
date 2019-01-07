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
        public static List<Drug> Select(string did)
        {
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            string sql = "SELECT * FROM drug WHERE `D_ID` LIKE '%" + did + "%'";
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
        //根据药品id查药品单价
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
        //药品ID查药品名称
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
        //判断药品名称是否存在
        public static bool ExistDrug(int did)
        {
            string sql = "select * from `hospital`.`drug` where D_ID='" + did + "'";
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader(CommandBehavior.CloseConnection);
            if (!odbcDataReader.HasRows)//商品ID不存在 返回空
            {
                return false;
            }
            else
                return true;
        }
        public static bool Insert(int did, string dname,string dstandard, float dpurchasingprice, float dsellingprice)
        {
            string sql = "insert into `hospital`.`drug` ( `D_ID`, `D_Name`, `D_Standard`,`D_PurchasingPrice`, `D_SellingPrice`,`D_Store`) " +
                "values('" + did + "', '" + dname + "'" +
                ",'" + dstandard + "','" + dpurchasingprice + "','" + dsellingprice + "',0)";
            return Tool.ExecuteSQL.ExecuteNonQuerySQL_GetBool(sql);
        }
        public static bool UpdateDrug(String did,int info)
        {
            string sql = "update `hospital`.`drug` set `D_Store` ='"+info+ "' where `D_ID`='"+Convert.ToInt32(did)+"'";
            return Tool.ExecuteSQL.ExecuteNonQuerySQL_GetBool(sql);
        }
        //根据药品ID查询库存
        public static int GetDrugStore(int did)
        {
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            string sql = "SELECT D_Store FROM `hospital`.`drug` WHERE `D_ID`='" + did + "'";
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader reader = odbcCommand.ExecuteReader();
            if (reader.Read())
            {
                int D_Store = Convert.ToInt32(reader[0]);
                odbcConnection.Close();
                return D_Store;
            }
            odbcConnection.Close();
            return 0;
        }
    }
}