using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospital.Models;
using Hospital.Controllers;

namespace Hospital.Views.Index
{
    public partial class NurseIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //根据session中保存的id添加tree
            Employee emp = Employee_C.SeekDep(Session["uid"].ToString());
            Department dep = Department_C.DE_seekname(emp.DE_ID.ToString());
            show_depart.InnerHtml = dep.DE_Name;
            //TreeNode root = new TreeNode(dep.DE_Name);
            //TreeView1.Nodes.Add(root);

        }

    }
}