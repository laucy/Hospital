using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;

namespace Hospital.Models
{
    public class Hospitalization
    {

        public int C_ID { get; set; }
        public int S_ID { get; set; }
        public DateTime H_In { get; set; }
        public DateTime H_Out { get; set; }
        public float H_Sum { get; set; }

        public Hospitalization() { }

        public Hospitalization(int cid, int sid,DateTime hin, DateTime hout,
             float hsum)
        {
            C_ID = cid;
            S_ID = sid;
            H_In = hin;
            H_Out =hout;
            H_Sum = hsum;          
        }

        public static List<Hospitalization> getList(OdbcDataReader reader)
        {
            List<Hospitalization> list = new List<Hospitalization>();
            Hospitalization hospitalizations;
            while (reader.Read())
            {
                hospitalizations = new Hospitalization();
                hospitalizations.C_ID = reader.GetInt32(0);
                hospitalizations.S_ID = reader.GetInt32(1);
                hospitalizations.H_In = reader.GetDate(2);
                hospitalizations.H_Out = reader.GetDate(3);
                hospitalizations.H_Sum = reader.GetFloat(4);               
                list.Add(hospitalizations);
            }
            return list;
        }
    }
}