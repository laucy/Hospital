using Hospital.Controllers.DB;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace Hospital.Controllers
{
	public class User_C
	{
        public static User U_Login(string id, string pwd)
        {
            OdbcConnection sqlConnection1 = DBManager.GetOdbcConnection();
            sqlConnection1.Open();
            OdbcCommand odbcCommand = new OdbcCommand("select * from user where U_Name='" + id + "' and U_Password='" + pwd + "'", sqlConnection1);
            OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader();

            if (odbcDataReader.HasRows)
            {
                List<User> list = User.getList(odbcDataReader);
                sqlConnection1.Close();
                return list[0];
            }
            else
                sqlConnection1.Close();
            return null;
        }
        //增加病人id和密码
        public static bool Insertpid(string patientid)
        {
            string sql = "insert into `hospital`.`user` ( `U_Name`, `U_Password`,`U_Role`) " +
                "values('" + Convert.ToInt32(patientid) + "',666666,6)";
            return Tool.ExecuteSQL.ExecuteNonQuerySQL_GetBool(sql);
        }
    }
}