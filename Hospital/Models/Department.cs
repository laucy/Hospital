using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
    public class Department
    {
        public string DE_ID { set; get; }
        public string DE_Name { set; get; }
        public Department()
        { }
        public Department(string id)
        {
            DE_ID = id;
        }

        internal static List<Department> getList(OdbcDataReader reader)
        {
            List<Department> list = new List<Department>();
            Department dep;
            while (reader.Read())
            {
                dep = new Department();
                dep.DE_ID = reader.GetInt32(0).ToString();
                dep.DE_Name = reader.GetString(1);
                list.Add(dep);
            }
            return list;
        }
    }
}