using Hospital.Controllers;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital.Views.SystemManagement.DepartmentManage
{
    public partial class DepartmentDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string departmentid = Request.QueryString["deid"];      
            if (departmentid != null) { 
               List<Department> departments = Department_C.GetDeinfobyID(departmentid);
               deid.Value = departments[0].DE_ID.ToString();
               dename.Value = departments[0].DE_Name;
            }

        }

        protected void update_Click(object sender, EventArgs e)
        {
            bool result =Department_C.UpdateDepartment(deid.Value,Request.Form["dename"]);
            if (result == true)
            {
                Response.Write("<script language=javascript>window.alert('修改成功！');</script>");
            }
            else
            {
                Response.Write("<script language=javascript>window.alert('修改失败！');</script>");
            }
            List<Department> departments = Department_C.GetDeinfobyID(deid.Value);
            deid.Value = departments[0].DE_ID.ToString();
            dename.Value = departments[0].DE_Name;
        }
        protected void delete_Click(object sender, EventArgs e)
        {
            bool result = Department_C.DeleteByID(deid.Value);
            if (result == true)
            {
                Response.Write("<script language=javascript>window.alert('删除成功！');window.location.href='DepartmentManage.aspx'</script>");
            }
            else
            {
                Response.Write("<script language=javascript>window.alert('删除失败！');</script>");
            }
        }
    }
}