using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Odbc;
using Hospital.Models;

namespace Hospital.Controllers
{
    public class Instrument_C
    {
        //根据仪器名称查找
        public static List<Instrument> SelectFuzzy(string info)
        {
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            string sql = "SELECT * FROM instrument WHERE `I_Name` LIKE '%" + info + "%'";
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader();
            if (odbcDataReader.HasRows)
            {
                List<Instrument> list = Instrument.getList(odbcDataReader);
                odbcConnection.Close();
                return list;
            }
            odbcConnection.Close();
            return null;
        }
        public static List<Instrument> Select(string iid)
        {
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            string sql = "SELECT * FROM instrument WHERE `I_ID` LIKE '%" + iid + "%'";
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader(CommandBehavior.CloseConnection);

            if (odbcDataReader.HasRows)
            {
                List<Instrument> list = Instrument.getList(odbcDataReader);
                odbcConnection.Close();
                return list;
            }
            else
                odbcConnection.Close();
            return null;
        }
        public static bool Insert(int iid, string iname, int inumber, int deid)
        {
            string sql = "insert into `hospital`.`instrument`  values('" + iid + "','" + iname + "','" + inumber + "','" + deid + "')";
            return Tool.ExecuteSQL.ExecuteNonQuerySQL_GetBool(sql);
        }
        public static bool Update(int iid, string iname, int inumber, int deid)
        {
            string sql = "UPDATE `hospital`.`instrument` SET I_Name='" + iname + "',I_Number='" + inumber + "',DE_ID='" +deid + "' WHERE I_ID='"+iid+"'";
            return Tool.ExecuteSQL.ExecuteNonQuerySQL_GetBool(sql);
        }
        public static bool DeleteByID(string iid)
        {
            string sql = "DELETE FROM `hospital`.`instrument` WHERE I_ID=" + iid;
            return Tool.ExecuteSQL.ExecuteNonQuerySQL_GetBool(sql);
        }
        public static bool isExert(int iid)
        {
            string sql = "select * from `hospital`.`instrument` where I_ID='" + iid + "'";
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader(CommandBehavior.CloseConnection);
            if (!odbcDataReader.HasRows)//仪器ID不存在 返回空
            {
                return false;
            }
            else
                return true;
        }
    }
}