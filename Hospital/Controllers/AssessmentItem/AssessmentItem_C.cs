﻿using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace Hospital.Controllers
{
    public class AssessmentItem_C
    {
        //根据检查项名称查检查项内容
        public static List<AssessmentItem> Select(string info)
        {
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            string sql = "SELECT * FROM assessment_item WHERE `IT_Name` LIKE '%" + info + "%'";
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader(CommandBehavior.CloseConnection);

            if (odbcDataReader.HasRows)
            {
                List<AssessmentItem> list = AssessmentItem.getList(odbcDataReader);
                odbcConnection.Close();
                return list;
            }
            else
                odbcConnection.Close();
            return null;
        }
        //判断检查项ID是否存在
        public static bool ExistText(int did)
        {
            string sql = "select * from `hospital`.`assessment_item` where IT_ID='" + did + "'";
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader(CommandBehavior.CloseConnection);
            if (!odbcDataReader.HasRows)//检查项ID不存在 返回空
            {
                return false;
            }
            else
                return true;
        }
        //根据检查项名称判断是否存在
        public static bool isExit(String itname)
        {
            string sql = "SELECT * FROM assessment_item WHERE `IT_Name` LIKE '%" + itname + "%'";
            return Tool.ExecuteSQL.ExecuteNonQuerySQL_GetBool(sql);
        }
        //根据检查项id查检查项单价
        public static float GetPrice(int did)
        {
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            string sql = "SELECT IT_Price FROM `hospital`.`assessment_item` WHERE `IT_ID`='" + did + "'";
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader reader = odbcCommand.ExecuteReader();
            if (reader.Read())
            {
                float IT_Price = (float)reader[0];
                odbcConnection.Close();
                return IT_Price;
            }
            odbcConnection.Close();
            return 0;
        }
        //检查项ID查检查项名称
        public static string GetTextname(int did)
        {
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            string sql = "SELECT IT_Name FROM `hospital`.`assessment_item` WHERE `IT_ID`='" + did + "'";
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader reader = odbcCommand.ExecuteReader();
            if (reader.Read())
            {
                string IT_Name = reader[0].ToString();
                odbcConnection.Close();
                return IT_Name;
            }
            odbcConnection.Close();
            return null;
        }
    }
}