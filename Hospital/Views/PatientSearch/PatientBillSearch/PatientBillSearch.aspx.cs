using Hospital.Controllers;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital.Views.PatientSearch.PatientBillSearch
{
    public partial class PatientBillSearch : System.Web.UI.Page
    {
        public List<Test> tests;
        public List<Patient> patients;
        public string sex;
        public List<Prescript> prescripts;
        public float[] sellingprice = new float[20];
        public List<Hospitalization> hospitalizations;
        float testsum;
        float prescriptsum;
        float hsum;
        protected void Page_Load(object sender, EventArgs e)
        {
            int patientid = Convert.ToInt32(Session["uid"]);
            patients = Patient_C.GetPatientinformation(patientid.ToString());
            if (patients[0].P_Sex == "男")
                sex = "先生";
            else
                sex = "女士";
            testsum = 0;
            prescriptsum = 0;
            hsum = 0;
            tests = Test_C.SelectTest(patientid);
            prescripts = Prescript_C.SelectPrescript(patientid);
            bool result = Hospitalization_C.AlterHospitalization(patientid);
            hospitalizations = Hospitalization_C.SelectHospitalization(patientid);
            if (prescripts != null)
            {
                for (int i = 0; i < prescripts.Count; i++)
                {
                    sellingprice[i] = Drug_C.GetSellingPrice(prescripts[i].D_ID);
                    prescriptsum += prescripts[i].D_Totalprice;
                }
            }
            if (tests != null)
                for (int i = 0; i < tests.Count; i++)
                {
                    testsum += tests[i].IT_Price;
                }
            if (hospitalizations != null)
                for (int i = 0; i < hospitalizations.Count; i++)
                {
                    hsum += hospitalizations[i].H_Sum;
                }
            sum1.Text = prescriptsum.ToString() + '元';
            sum2.Text = testsum.ToString() + '元';
            sum3.Text = hsum.ToString() + '元';
            sum.Text = (prescriptsum + testsum + hsum).ToString() + '元';

        }       
        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../Index/PatientIndex.aspx");
        }
    }
}