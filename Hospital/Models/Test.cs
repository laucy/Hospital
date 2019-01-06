using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;

namespace Hospital.Models
{
    public class Test
    {

        public int IT_ID { get; set; }
        public int C_ID { get; set; }
        public string IT_Name { get; set; }
        public DateTime T_Date { get; set; }
        public float IT_Price { get; set; }

        public Test() { }

        public Test(int itid, int cid, string itname,DateTime tdate ,float itprice)
        {
            IT_ID = itid;
            C_ID = cid;
            IT_Name = itname;
            T_Date = tdate;
            IT_Price = itprice;
        }

        public static List<Test> getList(OdbcDataReader reader)
        {
            List<Test> list = new List<Test>();
            Test tests;
            while (reader.Read())
            {
                tests = new Test();
                tests.IT_ID = reader.GetInt32(0);
                tests.C_ID = reader.GetInt32(1);
                tests.IT_Name = reader.GetString(2);
                tests.T_Date = reader.GetDate(3);
                tests.IT_Price = reader.GetFloat(4);
                list.Add(tests);
            }
            return list;
        }
    }
}