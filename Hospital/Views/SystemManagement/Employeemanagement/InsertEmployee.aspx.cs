using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospital.Models;
using Hospital.Controllers;

namespace Hospital.Views.SystemManagement.Employeemanagement
{
    public partial class InsertEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void insert_Click(object sender, EventArgs e)
        {
            if (Employee_C.Exist(Convert.ToInt32(E_ID.Value)) == true)
                Response.Write("<script language=javascript>window.alert('该员工已存在！');</script>");
            else
            {
                if (Employee_C.Insert(Convert.ToInt32(E_ID.Value), E_Name.Value, E_Sex.Value, Convert.ToInt32(E_Age.Value), Convert.ToInt32(DE_ID.Value), E_position.Value, E_phone.Value) == true && User_C.Inserteid(E_ID.Value, E_position.Value) == true)
                    Response.Write("<script language=javascript>window.alert('插入成功！');</script>");
                else
                    Response.Write("<script language=javascript>window.alert('插入失败！');</script>");
            }
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employeemanagement.aspx");
        }
    }
}