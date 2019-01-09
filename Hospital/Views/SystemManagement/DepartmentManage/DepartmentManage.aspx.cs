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
    public partial class DepartmentManage : System.Web.UI.Page
    {
        public List<Department> departmentinfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            departmentinfo = Department_C.GetDepartmentinfo();
        }

        protected void search_Click(object sender, EventArgs e)
        {
            if (deidtext.Value !="")
            {
                departmentinfo = Department_C.GetDeinfobyID(deidtext.Value);
            }
            else//根据科室名称模糊查询
            {
                departmentinfo = Department_C.GetDepartmentinfo(denametext.Value);
            }
        }

        protected void insert_Click(object sender, EventArgs e)
        {
            if (denametext.Value == ""||deidtext.Value=="")
            {
                Response.Write("<script language=javascript>window.alert('请输入科室名称和编号！');</script>");

            }
            else
            {
                bool result=Department_C.Insert(deidtext.Value,denametext.Value);
                departmentinfo = Department_C.GetDepartmentinfo();
                if (result == true)
                {
                    Response.Write("<script language=javascript>window.alert('插入成功！');</script>");
                }
                else
                {
                    Response.Write("<script language=javascript>window.alert('插入失败！');</script>");

                }
            }            
        }
    }
}