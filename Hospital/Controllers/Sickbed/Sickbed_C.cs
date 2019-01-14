using Hospital.Controllers.DB;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace Hospital.Controllers
{
    public class Sickbed_C
    {
        public static List<Sickbed> SickBed_Info(string dep)
        {
            OdbcConnection sqlConnection1 = DBManager.GetOdbcConnection();
            sqlConnection1.Open();
            OdbcCommand odbcCommand = new OdbcCommand("select * from sickbed where DE_ID='" + dep + "'", sqlConnection1);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader();

            if (odbcDataReader.HasRows)
            {
                List<Sickbed> list = Sickbed.getList(odbcDataReader);
                sqlConnection1.Close();
                return list;
            }
            else
                sqlConnection1.Close();
            return null;
        }
        public static bool DistributeBed(string sid, string cid)
        {
            OdbcConnection sqlConnection1 = DBManager.GetOdbcConnection();
            sqlConnection1.Open();            
            OdbcCommand odbcCommand = new OdbcCommand("UPDATE hospitalization SET S_ID='" + sid + "' WHERE C_ID='" + cid + "'", sqlConnection1);
            if(odbcCommand.ExecuteNonQuery() == 1)
            {
                odbcCommand = new OdbcCommand("UPDATE sickbed SET S_Bool='1' WHERE S_ID='" + sid + "'", sqlConnection1);
                if (odbcCommand.ExecuteNonQuery() == 1)
                {
                    sqlConnection1.Close();
                    return true;
                }                   
            }           
            sqlConnection1.Close();
            return false;
        }
        //根据病床号查询病床信息
        public static List<Sickbed> Getinfobysid(string sid = "")
        {
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            string sql = "SELECT * FROM `hospital`.`sickbed` "
                + "WHERE `S_ID`='" + sid + "'";
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader(CommandBehavior.CloseConnection);
            if (odbcDataReader.HasRows)
            {
                List<Sickbed> list = Sickbed.getList(odbcDataReader);
                odbcConnection.Close();
                return list;
            }
            odbcConnection.Close();
            return null;
        }
        //根据房间号模糊查询病床信息
        public static List<Sickbed> Getinfobyrid(string rid= "")
        {
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            string sql = "SELECT * FROM `hospital`.`sickbed` "
                + "WHERE `R_ID` LIKE'%" + rid + "%'";
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader(CommandBehavior.CloseConnection);
            if (odbcDataReader.HasRows)
            {
                List<Sickbed> list = Sickbed.getList(odbcDataReader);
                odbcConnection.Close();
                return list;
            }
            odbcConnection.Close();
            return null;
        }       
        //根据科室名称查询病床信息
        public static List<Sickbed> Getinfobydename(string dename = "")
        {
            string deid = Department_C.DE_seekid(dename);
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            string sql = "SELECT * FROM `hospital`.`sickbed` "
                + "WHERE `DE_ID`= '" + deid + "'";
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader(CommandBehavior.CloseConnection);
            if (odbcDataReader.HasRows)
            {
                List<Sickbed> list = Sickbed.getList(odbcDataReader);
                odbcConnection.Close();
                return list;
            }
            odbcConnection.Close();
            return null;
        }

        //insert
        public static bool Insert(string sid, string rid,string sbool,string dename )
        {
            string deid = Department_C.DE_seekid(dename);
            string sql = "insert into `hospital`.`sickbed` (`S_ID`,`R_ID`,`S_Bool`,`DE_ID`) values('" + sid + "','" + rid + "','" + sbool + "','" + deid + "')";
            return Tool.ExecuteSQL.ExecuteNonQuerySQL_GetBool(sql);
        }
        //update
        public static bool UpdateSickbed(string sid, string rid, int sbool, string dename)
        {
            string deid = Department_C.DE_seekid(dename);
            string sql = "UPDATE `hospital`.`sickbed` SET `R_ID`='" + rid + "',  `S_Bool`='" + sbool + "'," +
                " `DE_ID`='" + deid + "' WHERE `S_ID`='" + sid + "'";
            return Tool.ExecuteSQL.ExecuteNonQuerySQL_GetBool(sql);
        }
        //delete
        public static bool DeleteByID(string sid)
        {
            string sql = "DELETE FROM `hospital`.`sickbed` WHERE S_ID=" + sid;
            return Tool.ExecuteSQL.ExecuteNonQuerySQL_GetBool(sql);
        }
    }
}