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
    public partial class UpdateEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string eid = Request.QueryString["E_ID"];
            if(eid != "")
            {
                List<Employee> employees = Employee_C.Select(eid);
                E_ID.Value = employees[0].E_ID.ToString();
                E_Name.Value = employees[0].E_Name;
                E_Sex.Value = employees[0].E_Sex;
                E_Age.Value = employees[0].E_Age.ToString();
                DE_ID.Value = employees[0].DE_ID.ToString();
                E_position.Value = employees[0].E_Position;
                E_phone.Value = employees[0].E_Phone;
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            if(Employee_C.Update(Convert.ToInt32(E_ID.Value), Request.Form["E_Name"], Request.Form["E_Sex"],Convert.ToInt32(Request.Form["E_Age"]),Convert.ToInt32(Request.Form["DE_ID"]), Request.Form["E_position"], Request.Form["E_phone"])==true)
                Response.Write("<script language=javascript>window.alert('更新成功！');</script>");
            else
                Response.Write("<script language=javascript>window.alert('更新失败！');</script>");
            string eid = Request.QueryString["E_ID"];
            if (eid != "")
            {
                List<Employee> employees = Employee_C.Select(eid);
                E_ID.Value = employees[0].E_ID.ToString();
                E_Name.Value = employees[0].E_Name;
                E_Sex.Value = employees[0].E_Sex;
                E_Age.Value = employees[0].E_Age.ToString();
                DE_ID.Value = employees[0].DE_ID.ToString();
                E_position.Value = employees[0].E_Position;
                E_phone.Value = employees[0].E_Phone;
            }
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            if (Employee_C.DeleteByID(E_ID.Value)==true)
                Response.Write("<script language=javascript>window.alert('删除成功！');</script>");
            else
                Response.Write("<script language=javascript>window.alert('删除失败！');</script>");
        }
    }
}