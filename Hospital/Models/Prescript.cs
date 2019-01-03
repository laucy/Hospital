using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;
using Hospital.Models;

namespace Hospital.Models
{
    public class Prescript
    {

        public int D_ID { get; set; }
        public int C_ID { get; set; }
        public string D_Name { get; set; }
        public int D_Number { get; set; }
        public float D_Totalprice { get; set; }
        public DateTime P_Date { get; set; }
        public String P_Notes { get; set; }

        public Prescript() { }

        public Prescript(int did, int cid, string dname, int dnumber, float dtotalprice,DateTime pdate,String pnotes)
        {
            D_ID = did;
            C_ID = cid;
            D_Name = dname;
            D_Number = dnumber;
            D_Totalprice = dtotalprice;
            P_Date = pdate;
            P_Notes = pnotes;
        }

        public static List<Prescript> getList(OdbcDataReader reader)
        {
            List<Prescript> list = new List<Prescript>();
            Prescript prescript;
            while (reader.Read())
            {
                prescript = new Prescript();
                prescript.D_ID = reader.GetInt32(0);
                prescript.C_ID = reader.GetInt32(1);
                prescript.D_Name = reader.GetString(2);
                prescript.D_Number = reader.GetInt32(3);
                prescript.D_Totalprice = reader.GetFloat(4);
                prescript.P_Date = reader.GetDateTime(5);
                prescript.P_Notes = reader.GetString(6);
                list.Add(prescript);
            }
            return list;
        }
    }
}