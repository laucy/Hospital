﻿using Hospital.Models;
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
                + "WHERE `D_ID`= '" + deid + "'";
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
            string sql = "insert into `hospital`.`sickbed` (`S_ID`,`R_ID`,`S_Bool`,`D_ID`) values('" + sid + "','" + rid + "','" + sbool + "','" + deid + "')";
            return Tool.ExecuteSQL.ExecuteNonQuerySQL_GetBool(sql);
        }
        //update
        public static bool UpdateSickbed(string sid, string rid, int sbool, string dename)
        {
            string deid = Department_C.DE_seekid(dename);
            string sql = "UPDATE `hospital`.`sickbed` SET `R_ID`='" + rid + "',  `S_Bool`='" + sbool + "'," +
                " `D_ID`='" + deid + "' WHERE `S_ID`='" + sid + "'";
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