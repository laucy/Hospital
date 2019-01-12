using Hospital.Controllers;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital.Views.Nurse
{
    public partial class Nurse_AdviceManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dep=Session["dep"].ToString();
            string depid = Session["depid"].ToString();
            show_depart.InnerHtml = dep;
            //加载医嘱信息
            List<Case> c_list = Case_C.GetAll_Info(depid);
            if(c_list!=null)
            {
                int i = 0;
                foreach (Case ca in c_list)
                {
                    Patient p = Patient_C.GetSingle_pInfo(ca.P_ID.ToString());
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript" + i, "<script type='text/javascript'>AddTable('" + p.P_Name + "','" + p.P_Sex + "','" + p.P_Age + "','"+ca.C_Diagnose + "','" + ca.C_Advice + "');</script>");
                    i++;
                }
            }           
        }
    }
}