using Hospital.Controllers;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital.Views.Payment
{
    public partial class Payment : System.Web.UI.Page
    {
        public List<Test> tests;
        public List<Prescript> prescripts;
        public float[] sellingprice=new float[20];
        public List<Hospitalization> hospitalizations;
        float testsum;
        float prescriptsum;
        float hsum;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void search_Click(object sender, EventArgs e)
        {
            testsum = 0;
            prescriptsum = 0;
            hsum = 0;
            tests = Test_C.SelectTest(Convert.ToInt32(pid.Text));
            prescripts = Prescript_C.SelectPrescript(Convert.ToInt32(pid.Text));
            bool result = Hospitalization_C.AlterHospitalization(Convert.ToInt32(pid.Text));
            hospitalizations = Hospitalization_C.SelectHospitalization(Convert.ToInt32(pid.Text));
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
            if (hospitalizations!= null)
             for (int i = 0; i < hospitalizations.Count; i++)
             {
                    hsum += hospitalizations[i].H_Sum;
             }           
            sum1.Text = prescriptsum.ToString()+'元';
            sum2.Text = testsum.ToString()+ '元';
            sum3.Text = hsum.ToString()+ '元';
            sum.Text= (prescriptsum+testsum+hsum).ToString() + '元';
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            Response.Write("<script language=javascript>window.alert('缴费成功！');</script>");
            pid.Text ="";
            pname.Text = "";
            testsum = 0;
            prescriptsum = 0;
            hsum = 0;
            sum1.Text = prescriptsum.ToString() + '元';
            sum2.Text = testsum.ToString() + '元';
            sum3.Text = hsum.ToString() + '元';
            sum.Text = (prescriptsum + testsum + hsum).ToString() + '元';
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index/CashierIndex.aspx");
        }
    }
}