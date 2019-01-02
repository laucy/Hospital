using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;

namespace Hospital.Models
{
    public class AssessmentItem
    {
        public int IT_ID { get; set; }
        public string IT_Name { get; set; }
        public int I_ID { get; set; }
        public float IT_Price { get; set; }
        

        public AssessmentItem() { }

        public AssessmentItem(int itid, string itname, int iid,float itprice)
        {
            IT_ID = itid;
            IT_Name = itname;
            I_ID = iid;
            IT_Price = itprice;
        }

        public static List<AssessmentItem> getList(OdbcDataReader reader)
        {
            List<AssessmentItem> list = new List<AssessmentItem>();
            AssessmentItem assessments;
            while (reader.Read())
            {
                assessments = new AssessmentItem();
                assessments.IT_ID = reader.GetInt32(0);
                assessments.IT_Name = reader.GetString(1);
                assessments.I_ID = reader.GetInt32(2);
                assessments.IT_Price = reader.GetFloat(3); 
                list.Add(assessments);
            }
            return list;
        }
    }
}