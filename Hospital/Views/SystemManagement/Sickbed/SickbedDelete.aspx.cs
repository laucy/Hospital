using Hospital.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital.Views.SystemManagement.Sickbed
{
    public partial class SickbedDelete : System.Web.UI.Page
    {
        public List<Models.Sickbed> sickbedinfo;
        string sid = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            sid = Request.QueryString["sid"];
            
            if (sid != null)
            {
                sickbedinfo = Sickbed_C.Getinfobysid(sid);
                sidinput.Value = sid;
                ridinput.Value = sickbedinfo[0].R_ID.ToString();
                dnameinput.Value= Department_C.DE_seekname(sickbedinfo[0].DE_ID.ToString()).DE_Name;
                if (sickbedinfo[0].S_Bool == 0)
                    sboolinput.Value = "空";
                else
                    sboolinput.Value = "满";
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            int sbool;
            if (Request.Form["sboolinput"] == "空") sbool = 0;
            else sbool = 1;
            bool result = Sickbed_C.UpdateSickbed(sid, Request.Form["ridinput"], sbool, Request.Form["dnameinput"]);
            if (result == true)
            {
                Response.Write("<script language=javascript>window.alert('修改成功！');</script>");
            }
            else
            {
                Response.Write("<script language=javascript>window.alert('修改失败！');</script>");
            }          
            sickbedinfo = Sickbed_C.Getinfobysid(sid);
            sidinput.Value = sid;
            ridinput.Value = sickbedinfo[0].R_ID.ToString();
            dnameinput.Value = Department_C.DE_seekname(sickbedinfo[0].DE_ID.ToString()).DE_Name;
            if (sickbedinfo[0].S_Bool == 0)
                sboolinput.Value = "空";
            else
                sboolinput.Value = "满";
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            bool result = Sickbed_C.DeleteByID(sid);          
            if (result == true)
            {
                Response.Write("<script language=javascript>window.alert('删除成功！');</script>");
                Response.Redirect("SickbedManage.aspx");
            }
            else
            {
                Response.Write("<script language=javascript>window.alert('删除失败！');</script>");
            }
        }
    }
}