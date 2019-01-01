using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospital.Models;
using Hospital.Controllers;
namespace Hospital.Views.Doctor
{
    public partial class Case : System.Web.UI.Page
    {
       public List<Patient> patient1=null;
        protected void Page_Load(object sender, EventArgs e)
        {
            name1.Value = "";
            sex1.Value = "";
            age1.Value = "";
            phone1.Value = "";
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            String s = textsearch.Value.ToString();
            patient1 = Patient_C.GetPatientinformation(s);
            name1.Value =  patient1[0].P_Name;
            sex1.Value = patient1[0].P_Sex;
            age1.Value = Convert.ToString(patient1[0].P_Age);
            phone1.Value = Convert.ToString(patient1[0].P_Phone);
        }
    }
}