using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.Controllers.Doctor
{
    public class Case_C
    {
        //增
        public static bool Insert(int pid, int eid, string ccomplain, string cdiagnose,string cadvice)
        {
            string sql = "insert into `hospital`.`case` ( `P_ID`, `E_ID`,`C_Complain`, `C_Diagnose`, `C_Advice`) " +
                "values('" + Convert.ToInt32(pid) + "', '" + Convert.ToInt32(eid) + "'" +
                ",'" + ccomplain + "','" + cdiagnose + "','" + cadvice + "')";
            return Tool.ExecuteSQL.ExecuteNonQuerySQL_GetBool(sql);
        }
    }
}