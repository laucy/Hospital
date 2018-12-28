using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;

namespace Hospital.Models
{
    public class Patient
    {
        public int P_ID { get; set; }
        public string P_Name { get; set; }
        public string P_Sex { get; set; }
        public int P_Age { get; set; }
        public int P_Phone { get; set; }

        public Patient() { }
       
        public Patient( int pid, string pname, string psex, int page,
             int pphone)
        {
            P_ID = pid;
            P_Name = pname;
            P_Sex = psex;
            P_Age = page;
            P_Phone = pphone;
        }

        public static List<Patient> getList(OdbcDataReader reader)
        {
            List<Patient> list = new List<Patient>();
            Patient patient;
            while (reader.Read())
            {
                patient = new Patient();
                patient.P_ID = reader.GetInt32(0);
                patient.P_Name = reader.GetString(1);
                patient.P_Sex = reader.GetString(2);
                patient.P_Age = reader.GetInt32(3);
                patient.P_Phone = reader.GetInt32(4);
                list.Add(patient);
            }
            return list;
        }
    }
}