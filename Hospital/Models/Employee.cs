using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
    public class Employee
    {
        public int E_ID { get; set; }
        public string E_Name { get; set; }
        public string E_Sex { get; set; }
        public int E_Age { set; get; }
        public int DE_ID { get; set; }
        public string E_Position { get; set; }             
        public string E_Phone { get; set; }
        public Employee() { }

        public Employee(string ename, string esex,int eage, int deid,string ephone, 
             string eposition)
        {
            E_Name = ename;
            E_Sex = esex;
            E_Age = eage;
            DE_ID = deid;
            E_Position = eposition;
            E_Phone = ephone;
        }

        public static List<Employee> getList(OdbcDataReader reader)
        {
            List<Employee> list = new List<Employee>();
            Employee employee;
            while (reader.Read())
            {
                employee = new Employee();
                employee.E_ID = reader.GetInt32(0);
                employee.E_Name = reader.GetString(1);
                employee.E_Sex = reader.GetString(2);
                employee.E_Age = reader.GetInt32(3);
                employee. DE_ID=reader.GetInt32(4);//科室编号
                //查找科室名称               
                employee.E_Position = reader.GetString(5);
                employee.E_Phone = reader.GetString(6);
                list.Add(employee);
            }
            return list;
        }
    }
}