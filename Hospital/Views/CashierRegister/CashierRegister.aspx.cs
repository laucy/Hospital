using Hospital.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospital.Controllers.Doctor;
using Hospital.Controllers;
using Hospital.Models;

namespace Hospital.Views.CashierRegister
{
    public partial class CashierRegister : System.Web.UI.Page
    {
        public List<Department> de;
        protected void Page_Load(object sender, EventArgs e)
        {
            de = Department_C.GetDepartmentName();
            this.department.DataSource = de;
            this.department.DataTextField = "DE_Name";
            this.department.DataBind();
        }

       protected void cashbutton_Click(object sender, EventArgs e)
        {
             bool result = Patient_C.Insert(pname.Value,psex.Value,ppage.Value, pphone.Value);           
             if (result)
             {
                 string patientid = Patient_C.GetPatientid(pname.Value);
                 bool resultcase = Case_C.Insert(Convert.ToInt32(patientid),1000,null, null, null);
                 Response.Write("<script language=javascript>window.alert('挂号成功,您的编号为:"+ patientid + "');</script>");              
                 pname.Value = null;
                 psex.Value = "男";
                 ppage.Value = null;
                 pphone.Value = null;
             }
             else
             {
                 Response.Write("<script language=javascript>window.alert('挂号失败！');</script>");
             }
        }

        protected void backbutton_Click(object sender, EventArgs e)
        {
            pname.Value = null;
            psex.Value = "男";
            ppage.Value = null;
            pphone.Value = null;
        }

        protected void department_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}