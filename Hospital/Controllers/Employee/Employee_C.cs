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
    public class Employee_C
    {
        public static Employee SeekDep(string id)
        {
            OdbcConnection sqlConnection1 = DBManager.GetOdbcConnection();
            sqlConnection1.Open();
            OdbcCommand odbcCommand = new OdbcCommand("select * from employee where E_ID='" + id + "'", sqlConnection1);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader();

            if (odbcDataReader.HasRows)
            {
                List<Employee> list = Employee.getList(odbcDataReader);
                sqlConnection1.Close();
                return list[0];
            }
            else
                sqlConnection1.Close();
            return null;
        }
        //根据姓名查找员工信息
        public static List<Employee> SelectFuzzy(string info)
        {
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            string sql = "SELECT * FROM employee WHERE `E_Name` LIKE '%" + info + "%'";
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader();
            if (odbcDataReader.HasRows)
            {
                List<Employee> list = Employee.getList(odbcDataReader);
                odbcConnection.Close();
                return list;
            }
            odbcConnection.Close();
            return null;
        }
        //根据员工ID查找员工信息
        public static List<Employee> Select(string eid)
        {
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            string sql = "SELECT * FROM employee WHERE `E_ID` LIKE '%" + eid + "%'";
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader(CommandBehavior.CloseConnection);

            if (odbcDataReader.HasRows)
            {
                List<Employee> list = Employee.getList(odbcDataReader);
                odbcConnection.Close();
                return list;
            }
            else
                odbcConnection.Close();
            return null;
        }
        //根据科室名字查找该科室所有医生名字
        public static List<Employee> SelectEmployee(string dename)
        {
            string deid = Department_C.DE_seekid(dename);
            string sql = "SELECT * FROM `hospital`. `employee` WHERE `DE_ID`='" + deid + "' and `E_Position`='3'";
            OdbcConnection odbcConnection = DBManager.GetOdbcConnection();
            odbcConnection.Open();
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader(CommandBehavior.CloseConnection);
            if (odbcDataReader.HasRows)
            {
                List<Employee> list = Employee.getList(odbcDataReader);
                odbcConnection.Close();
                return list;
            }
            else
                odbcConnection.Close();
            return null;
        }
        //插入员工信息
        public static bool Insert(int eid, string ename,string esex,int eage, int ieid,String eposition,string ephone)
        {
            string sql = "insert into `hospital`.`employee`  values('" + eid + "','" + ename + "','" + esex + "','" + eage + "','" + ieid + "','" + eposition + "','" + ephone + "')";
            return Tool.ExecuteSQL.ExecuteNonQuerySQL_GetBool(sql);
        }
        public static bool Update(int eid, string ename, string esex, int eage, int ieid, String eposition, string ephone)
        {
            string sql = "UPDATE `hospital`.`employee` SET E_Name='" + ename + "',E_Sex='" + esex + "',E_Age='" + eage + "',DE_ID='" + ieid + "',E_Position='" + eposition + "',E_Phone='" + ephone + "' WHERE `E_ID`='" + eid + "'";
            return Tool.ExecuteSQL.ExecuteNonQuerySQL_GetBool(sql);
        }
        public static bool DeleteByID(string eid)
        {
            string sql = "DELETE FROM `hospital`.`Employee` WHERE E_ID=" + eid;
            return Tool.ExecuteSQL.ExecuteNonQuerySQL_GetBool(sql);
        }
        public static bool Exist(int eid)
        {
            string sql = "select * from `hospital`.`employee` where E_ID='" + eid + "'";
            OdbcConnection odbcConnection = DB.DBManager.GetOdbcConnection();
            odbcConnection.Open();
            OdbcCommand odbcCommand = new OdbcCommand(sql, odbcConnection);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader(CommandBehavior.CloseConnection);
            if (!odbcDataReader.HasRows)//药品ID不存在 返回空
            {
                return false;
            }
            else
                return true;
        }
    }
}