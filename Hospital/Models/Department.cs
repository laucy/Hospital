using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;

namespace Hospital.Models
{
    public class Department
    {
        public int DE_ID { get; set; }
        public string DE_Name { get; set; }
        
        public Department() { }

        public Department(int deid, string dename)
        {
            DE_ID = deid;
            DE_Name = dename;          
        }
        //id和名称均获取
        public static List<Department> getList(OdbcDataReader reader)
        {
            List<Department> list = new List<Department>();
            Department department;
            while (reader.Read())
            {
                department = new Department();
                department.DE_ID = reader.GetInt32(0);
                department.DE_Name = reader.GetString(1);              
                list.Add(department);
            }
            return list;
        }
        //只获取名称
        public static List<Department> getList2(OdbcDataReader reader)
        {
            List<Department> list = new List<Department>();
            Department department;
            while (reader.Read())
            {
                department = new Department();
                department.DE_Name = reader.GetString(0);
                list.Add(department);
            }
            return list;
        }
    }
}