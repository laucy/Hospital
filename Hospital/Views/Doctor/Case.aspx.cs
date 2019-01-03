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
        public List<Drug> drugs;
        public static List<Prescript> prescripts =new List<Prescript>();
        Prescript prescript;
        public int i;
        protected void Page_Load(object sender, EventArgs e)
        {
            name1.Value = "";
            sex1.Value = "";
            age1.Value = "";
            phone1.Value = "";
            drugs = Drug_C.SelectFuzzy("");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            String s = patient_ID.Value.ToString();
            patient1 = Patient_C.GetPatientinformation(s);
            name1.Value =  patient1[0].P_Name;
            sex1.Value = patient1[0].P_Sex;
            age1.Value = Convert.ToString(patient1[0].P_Age);
            phone1.Value = Convert.ToString(patient1[0].P_Phone);
        }

        protected void search_drug_Click(object sender, EventArgs e)
        {
            String s = patient_ID.Value.ToString();
            patient1 = Patient_C.GetPatientinformation(s);
            drugs = Drug_C.SelectFuzzy(drug_name.Value);
            name1.Value = patient1[0].P_Name;
            sex1.Value = patient1[0].P_Sex;
            age1.Value = Convert.ToString(patient1[0].P_Age);
            phone1.Value = Convert.ToString(patient1[0].P_Phone);
            try { }
            catch { Response.Write("<script language=javascript>window.alert('挂号失败！');</script>"); }
        }

        protected void add_drug_Click(object sender, EventArgs e)
        {
            prescript = new Prescript();
            prescript.D_ID = Convert.ToInt32(drug_number.Value);
          //  Case_C.GetCaseID(Convert.ToInt32(patient_ID.Value));
            prescript.C_ID =Convert.ToInt32( Case_C.GetCaseID(Convert.ToInt32(patient_ID.Value)));
            prescript.D_Name = drug_name.Value;
            prescript.D_Number = Convert.ToInt32(drug_name.Value);

        //    prescript.D_Totalprice = Convert.ToDouble(d);
            prescript.P_Notes = drug_note.Value;
            prescripts.Add(prescript);
        }
    }
}