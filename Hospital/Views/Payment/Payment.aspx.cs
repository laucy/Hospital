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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void search_Click(object sender, EventArgs e)
        {
            float testsum = 0;
            float prescriptsum = 0;

            tests = Test_C.SelectTest(Convert.ToInt32(pid.Text));
            //prescripts= Prescript_C.SelectPrescript()
            if (tests != null)
             for (int i = 0; i < tests.Count; i++)
             {
                    testsum += tests[i].IT_Price;
    
             }
            sum2.Text = testsum.ToString();
        }
            
    }
}