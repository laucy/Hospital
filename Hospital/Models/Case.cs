using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;

namespace Hospital.Models
{
    public class Case
    {
        public int C_ID { get; set; }
        public int P_ID { get; set; }
        public int E_ID { get; set; }
        public string C_Complain { get; set; }
        public string C_Diagnose { get; set; }
        public string C_Advice { get; set; }
        public string H_Flag { get; set; }


        public Case() { }

        public Case(int cid, int pid, int eid,string ccomplain, string cdiagnose,
             string cadvice,string hflag)
        {
            C_ID = cid;
            P_ID = pid;
            E_ID = eid;
            C_Complain = ccomplain;
            C_Diagnose = cdiagnose;
            C_Advice = cadvice;
            H_Flag = hflag;
        }

        public static List<Case> getList(OdbcDataReader reader)
        {
            List<Case> list = new List<Case>();
            Case cases;
            while (reader.Read())
            {
                cases = new Case();
                cases.C_ID = reader.GetInt32(0);
                cases.P_ID = reader.GetInt32(1);
                cases.E_ID = reader.GetInt32(2);
                cases.C_Complain = reader.GetString(3);
                cases.C_Diagnose = reader.GetString(4);
                cases.C_Advice = reader.GetString(5);
                cases.H_Flag = reader.GetString(6);
                list.Add(cases);
            }
            return list;
        }
    }
}