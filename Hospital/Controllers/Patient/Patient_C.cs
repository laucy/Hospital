using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Odbc;

namespace Hospital.Controllers.Patient
{
    public class Patient_C
    {      
        //增
        public static bool Insert(string pname, string psex, int page,int pphone)
        {
            string sql = "insert into `hospital`.`patient` (`P_Name`, `P_Sex`, `P_Age`,`P_Phone`) " +
                "values('" + pname + "', '" + psex + "', '" + page + "','"+pphone+"')";       
            return Tool.ExecuteSQL.ExecuteNonQuerySQL_GetBool(sql);
        }
    }
}