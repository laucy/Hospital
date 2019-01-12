using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospital.Models;
using Hospital.Controllers;
using System.Web.Services;

namespace Hospital.Views.Index
{
    public partial class NurseIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //根据session中保存的id添加所属科室
            Employee emp = Employee_C.SeekDep(Session["uid"].ToString());
            Department dep = Department_C.DE_seekname(emp.DE_ID.ToString());
            Session["dep"] = dep.DE_Name;
            show_depart.InnerHtml = dep.DE_Name;

            //加载病床信息
            List<Sickbed> sb_list = Sickbed_C.SickBed_Info(dep.DE_ID.ToString());
            int i = 0;
            foreach (Sickbed sb in sb_list)
            {
                //Response.Write("<script languge='javascript'>alert('病床信息');</script>");
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript" + i, "<script type='text/javascript'>AddTable('" + sb.R_ID + "','" + sb.S_ID + "','" + sb.D_ID + "','" + sb.S_Bool + "');</script>");
                i++;
            }
        }
        [WebMethod]
        public static void Distribute(string sid, string cid)
        {
            Sickbed_C.DistributeBed(sid, cid);
        }
    }
}