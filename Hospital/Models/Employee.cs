using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
    public class Employee
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Age { set; get; }
        public string Department { get; set; }
        public string Phone { get; set; }             
        public int Position { get; set; }
        public Employee() { }

        public Employee(string name, string sex, string phone, 
             int position)
        {
            Name = name;
            Sex = sex;
            Phone = phone;           
            Position = position;
        }

        public static List<Employee> getList(OdbcDataReader reader)
        {
            List<Employee> list = new List<Employee>();
            Employee employee;
            while (reader.Read())
            {
                employee = new Employee();
                employee.ID = reader.GetInt32(0).ToString();
                employee.Name = reader.GetString(1);
                employee.Sex = reader.GetString(2);
                int De_id = reader.GetInt32(3);//科室编号
                //查找科室名称
                employee.Phone = reader.GetString(3);
                employee.Position = reader.GetInt32(4);
                list.Add(employee);
            }
            return list;
        }
    }
}