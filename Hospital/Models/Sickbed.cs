using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;

namespace Hospital.Models
{
    public class Sickbed
    {
        public int S_ID { get; set; }
        public int R_ID { get; set; }
        public int S_Bool { get; set; }
        public int DE_ID { get; set; }

        public Sickbed() { }

        public Sickbed(int sid, int rid, int sbool,int deid)
        {
            S_ID = sid;
            R_ID = rid;
            S_Bool = sbool;
            DE_ID = deid;
        }

        public static List<Sickbed> getList(OdbcDataReader reader)
        {
            List<Sickbed> list = new List<Sickbed>();
            Sickbed sickbeds;
            while (reader.Read())
            {
                sickbeds = new Sickbed();
                sickbeds.S_ID = reader.GetInt32(0);
                sickbeds.R_ID = reader.GetInt32(1);
                sickbeds.S_Bool = reader.GetInt32(2);
                sickbeds.DE_ID = reader.GetInt32(3);                
                list.Add(sickbeds);
            }
            return list;
        }
    }
}