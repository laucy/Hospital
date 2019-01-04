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
        public List<AssessmentItem> assessmentItems;
        public static List<Test> tests = new List<Test>();
        Test test;
        public int i,j,k,l;
        public Case case1; 
        protected void Page_Load(object sender, EventArgs e)
        {
            name1.Value = "";
            sex1.Value = "";
            age1.Value = "";
            phone1.Value = "";
            drugs = Drug_C.SelectFuzzy("");
            assessmentItems = AssessmentItem_C.Select("");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            String s = patient_ID.Value.ToString();
            patient1 = Patient_C.GetPatientinformation(s);
            name1.Value = " 姓名："+patient1[0].P_Name+"";
            sex1.Value = " 性别："+patient1[0].P_Sex+"";
            age1.Value = " 年龄："+Convert.ToString(patient1[0].P_Age)+"";
            phone1.Value = " 手机号："+Convert.ToString(patient1[0].P_Phone)+"";
            name1.Visible = true;
            sex1.Visible = true;
            age1.Visible = true;
            phone1.Visible = true;
        }

        protected void search_drug_Click(object sender, EventArgs e)
        {
            try
            {
                String s = patient_ID.Value.ToString();
                patient1 = Patient_C.GetPatientinformation(s);
            }
            catch { Response.Write("<script language=javascript>window.alert('查找失败！');</script>"); }
            drugs = Drug_C.SelectFuzzy(drug_name.Value);
            drug_name.Value = "";
            name1.Value = " 姓名：" + patient1[0].P_Name + "";
            sex1.Value = " 性别：" + patient1[0].P_Sex + "";
            age1.Value = " 年龄：" + Convert.ToString(patient1[0].P_Age) + "";
            phone1.Value = " 手机号：" + Convert.ToString(patient1[0].P_Phone) + "";
            name1.Visible = true;
            sex1.Visible = true;
            age1.Visible = true;
            phone1.Visible = true;
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string str;
            drug_ID.Value = "";
            drug_name.Value = "";
            drug_number.Value = "";
            drug_note.Value = "";
            Text_ID.Value = "";
            Text_Name.Value = "";
           Prescript_C.AddPrescript(prescripts);
            Test_C.AddTest(tests);
            if (hospitalization.Checked == true)
                str = "1";
            else
                str = "0";
          Case_C.UpdateCase(Convert.ToInt32(patient_ID.Value),Case_Complain.Value,Case_Diagnose.Value,Case_Advice.Value,str);
            Response.Write("<script language=javascript>window.alert('病历提交成功！');</script>");
            String s = patient_ID.Value.ToString();
            patient1 = Patient_C.GetPatientinformation(s);
            name1.Value = " 姓名：" + patient1[0].P_Name + "";
            sex1.Value = " 性别：" + patient1[0].P_Sex + "";
            age1.Value = " 年龄：" + Convert.ToString(patient1[0].P_Age) + "";
            phone1.Value = " 手机号：" + Convert.ToString(patient1[0].P_Phone) + "";
        }

        protected void Button_search_text_Click(object sender, EventArgs e)
        {
            String s = patient_ID.Value.ToString();
            patient1 = Patient_C.GetPatientinformation(s);
            assessmentItems = AssessmentItem_C.Select(Text_Name.Value);
            Text_Name.Value = "";
            name1.Value = " 姓名：" + patient1[0].P_Name + "";
            sex1.Value = " 性别：" + patient1[0].P_Sex + "";
            age1.Value = " 年龄：" + Convert.ToString(patient1[0].P_Age) + "";
            phone1.Value = " 手机号：" + Convert.ToString(patient1[0].P_Phone) + "";
            name1.Visible = true;
            sex1.Visible = true;
            age1.Visible = true;
            phone1.Visible = true;
        }

        protected void Button_add_text_Click(object sender, EventArgs e)
        {
            String s = patient_ID.Value.ToString();
            patient1 = Patient_C.GetPatientinformation(s);
            name1.Value = " 姓名：" + patient1[0].P_Name + "";
            sex1.Value = " 性别：" + patient1[0].P_Sex + "";
            age1.Value = " 年龄：" + Convert.ToString(patient1[0].P_Age) + "";
            phone1.Value = " 手机号：" + Convert.ToString(patient1[0].P_Phone) + "";
            test= new Test();
            test.IT_ID = Convert.ToInt32(Text_ID.Value);
            test.C_ID = Convert.ToInt32(Case_C.GetCaseID(Convert.ToInt32(patient_ID.Value)));
            test.IT_Name = AssessmentItem_C.GetTextname(Convert.ToInt32(Text_ID.Value));
            test.IT_Price = AssessmentItem_C.GetPrice(Convert.ToInt32(Text_ID.Value));
            tests.Add(test);
            drug_ID.Value = "";
            drug_name.Value = "";
            drug_number.Value = "";
            drug_note.Value = "";
            Text_ID.Value = "";
            Text_Name.Value = "";
        }

        protected void add_drug_Click(object sender, EventArgs e)
        {
            String s = patient_ID.Value.ToString();
            patient1 = Patient_C.GetPatientinformation(s);
            name1.Value = " 姓名：" + patient1[0].P_Name + "";
            sex1.Value = " 性别：" + patient1[0].P_Sex + "";
            age1.Value = " 年龄：" + Convert.ToString(patient1[0].P_Age) + "";
            phone1.Value = " 手机号：" + Convert.ToString(patient1[0].P_Phone) + "";
            prescript = new Prescript();
            prescript.D_ID = Convert.ToInt32(drug_ID.Value);
            prescript.C_ID =Convert.ToInt32( Case_C.GetCaseID(Convert.ToInt32(patient_ID.Value)));
            prescript.D_Name = Drug_C.GetDrugname(Convert.ToInt32(drug_ID.Value));
            prescript.D_Number = Convert.ToInt32(drug_number.Value);
            prescript.D_Totalprice =(float)Convert.ToDouble(((Drug_C.GetSellingPrice(Convert.ToInt32(drug_ID.Value))) * (Convert.ToInt32(drug_number.Value))));
            prescript.P_Notes = drug_note.Value;
            prescripts.Add(prescript);
            drug_ID.Value = "";
            drug_name.Value = "";
            drug_number.Value = "";
            drug_note.Value = "";
            Text_ID.Value = "";
            Text_Name.Value = "";
        }
    }
}