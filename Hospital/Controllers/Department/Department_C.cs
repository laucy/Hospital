using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital.Models;
using System.Data.Odbc;
using Hospital.Controllers.DB;
using System.Data;

namespace Hospital.Controllers
{
    public class Department_C
    {
        //根据科室id查询科室名字
        public static Department DE_seekname(string id)
        {
            OdbcConnection sqlConnection1 = DBManager.GetOdbcConnection();
            sqlConnection1.Open();
            OdbcCommand odbcCommand = new OdbcCommand("select * from department where DE_ID='" + id + "'", sqlConnection1);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader();

            if (odbcDataReader.HasRows)
            {
                List<Department> list = Department.getList(odbcDataReader);
                sqlConnection1.Close();
                return list[0];
            }
            else
                sqlConnection1.Close();
            return null;
        }
        //获取现在的所有科室名称
        public static List<Department> GetDepartmentName()
        {
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            string sql = "SELECT DE_Name FROM `hospital`.`department` ";
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader(CommandBehavior.CloseConnection);
            if (odbcDataReader.HasRows)
            {
                List<Department> list = Department.getList2(odbcDataReader);
                odbcConnection.Close();
                return list;
            }
            odbcConnection.Close();
            return null;
        }

        //获取科室信息
        public static List<Department> GetDepartmentinfo()
        {
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            string sql = "SELECT * FROM `hospital`.`department` ";
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader(CommandBehavior.CloseConnection);
            if (odbcDataReader.HasRows)
            {
                List<Department> list = Department.getList(odbcDataReader);
                odbcConnection.Close();
                return list;
            }
            odbcConnection.Close();
            return null;
        }

        //根据科室名称获取科室id
        public static string DE_seekid(string dename)
        {
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            string sql = "SELECT * FROM `hospital`.`department` WHERE `DE_NAME`='" + dename + "'";
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader reader = odbcCommand.ExecuteReader();
            if (reader.Read())
            {
                string deid = reader[0].ToString();
                odbcConnection.Close();
                return deid;
            }
            odbcConnection.Close();
            return null;
        }

        //根据科室名称模糊查询
        public static List<Department> GetDepartmentinfo(string dename= "")
        {
            OdbcConnection odbcConnection = DBManager.GetOdbcConnection();
            odbcConnection.Open();
            string sql = "SELECT * FROM `hospital`.`department` "
                + "WHERE `DE_Name` Like '%" + dename + "%'";
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader(CommandBehavior.CloseConnection);
            if (odbcDataReader.HasRows)
            {
                List<Department> list = Department.getList(odbcDataReader);
                odbcConnection.Close();
                return list;
            }
            odbcConnection.Close();
            return null;
        }
        //根据科室id查询科室信息
        public static List<Department> GetDeinfobyID(string deid)
        {
            OdbcConnection odbcConnection = DBManager.GetOdbcConnection();
            odbcConnection.Open();
            string sql = "SELECT * FROM `hospital`.`department` "
                + "WHERE `DE_ID`='"+deid+"'";
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader(CommandBehavior.CloseConnection);
            if (odbcDataReader.HasRows)
            {
                List<Department> list = Department.getList(odbcDataReader);
                odbcConnection.Close();
                return list;
            }
            odbcConnection.Close();
            return null;
        }

        //insert
        public static bool Insert(string deid,string dename)
        {
            string sql = "insert into `hospital`.`department` (`DE_ID`,`DE_Name`) values('"+deid+"','" + dename + "')";
            return Tool.ExecuteSQL.ExecuteNonQuerySQL_GetBool(sql);
        }
        //update
        public static bool UpdateDepartment(string deid,string dename)
        {
            string sql = "UPDATE `hospital`.`department` SET `DE_Name`='" + dename + "' WHERE `DE_ID`='"+deid+"'";
            return Tool.ExecuteSQL.ExecuteNonQuerySQL_GetBool(sql);
        }
        //delete
        public static bool DeleteByID(string deid)
        {
            string sql = "DELETE FROM `hospital`.`department` WHERE DE_ID=" + deid;
            return Tool.ExecuteSQL.ExecuteNonQuerySQL_GetBool(sql);
        }

    }
}