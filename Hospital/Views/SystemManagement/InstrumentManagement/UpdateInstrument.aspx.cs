using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospital.Models;
using Hospital.Controllers;

namespace Hospital.Views.SystemManagement.InstrumentManagement
{
    public partial class UpdateInstrument : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string iid = Request.QueryString["I_ID"];
            if (iid != "")
            {
                List<Instrument> instruments = Instrument_C.Select(iid);
                I_ID.Value = instruments[0].I_ID.ToString();
                I_Name.Value = instruments[0].I_Name;
                I_Number.Value = instruments[0].I_Number.ToString();
                DE_ID.Value = instruments[0].DE_ID.ToString();
            }

        }

        protected void update_Click(object sender, EventArgs e)
        {
            if (Instrument_C.Update(Convert.ToInt32(I_ID.Value),Request.Form["I_Name"], Convert.ToInt32(Request.Form["I_Number"]), Convert.ToInt32(Request.Form["DE_ID"])) ==true)
                Response.Write("<script language=javascript>window.alert('更新成功！');</script>");
            else
                Response.Write("<script language=javascript>window.alert('更新失败！');</script>");
            string iid = Request.QueryString["I_ID"];
            if (iid != "")
            {
                List<Instrument> instruments = Instrument_C.Select(iid);
                I_ID.Value = instruments[0].I_ID.ToString();
                I_Name.Value = instruments[0].I_Name;
                I_Number.Value = instruments[0].I_Number.ToString();
                DE_ID.Value = instruments[0].DE_ID.ToString();
            }
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            if(Instrument_C.DeleteByID(I_ID.Value) == true)
                Response.Write("<script language=javascript>window.alert('删除成功！');</script>");
            else
                Response.Write("<script language=javascript>window.alert('删除失败！');</script>");

        }
    }
}