using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;

namespace Hospital.Models
{
    public class Instrument
    {
        public int I_ID { get; set; }
        public string I_Name { get; set; }
        public int I_Number { get; set; }
        public int DE_ID { get; set; }

        public Instrument() { }

        public Instrument(int iid, string iname, int inumber, int deid)
        {
            I_ID = iid;
            I_Name = iname;
            I_Number = inumber;
            DE_ID = deid;
        }

        public static List<Instrument> getList(OdbcDataReader reader)
        {
            List<Instrument> list = new List<Instrument>();
            Instrument instruments;
            while (reader.Read())
            {
                instruments = new Instrument();
                instruments.I_ID = reader.GetInt32(0);
                instruments.I_Name = reader.GetString(1);
                instruments.I_Number = reader.GetInt32(2);
                instruments.DE_ID = reader.GetInt32(3);
                list.Add(instruments);
            }
            return list;
        }
    }
}