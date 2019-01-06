using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;
using Hospital.Models;

namespace Hospital.Models
{
    public class Drug
    {
        public int D_ID { get; set; }
        public string D_Name { get; set; }
        public string D_Standard { get; set; }
        public float D_PurchasingPrice { get; set; }
        public float D_SellingPrice { get; set; }
        public int D_Store { get; set; }

        public Drug() { }

        public Drug(int did, string dname, string dstandard, float dpurchasingprice,float dsellingprice,int dstore)
        {
            D_ID = did;
            D_Name = dname;
            D_Standard = dstandard;
            D_PurchasingPrice = dpurchasingprice;
            D_Store = dstore;
        }

        public static List<Drug> getList(OdbcDataReader reader)
        {
            List<Drug> list = new List<Drug>();
            Drug drug;
            while (reader.Read())
            {
                drug = new Drug();
                drug.D_ID = reader.GetInt32(0);
                drug.D_Name = reader.GetString(1);
                drug.D_Standard = reader.GetString(2);
                drug.D_PurchasingPrice = reader.GetInt32(3);
                drug.D_SellingPrice = reader.GetFloat(4);
                drug.D_Store = reader.GetInt32(5);
                list.Add(drug);
            }
            return list;
        }
    }
}