using Hospital.Controllers;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital.Views.SystemManagement.InstrumentManagement
{
    public partial class InsertInstrument : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void insert_Click(object sender, EventArgs e)
        {
            if (Instrument_C.isExert(Convert.ToInt32(I_ID.Value)) == true)
                Response.Write("<script language=javascript>window.alert('该仪器已存在！');</script>");
            else
            {
                if (Instrument_C.Insert(Convert.ToInt32(I_ID.Value), I_Name.Value, Convert.ToInt32(I_Number.Value), Convert.ToInt32(DE_ID.Value)) == true)
                    Response.Write("<script language=javascript>window.alert('插入成功！');</script>");
                else
                    Response.Write("<script language=javascript>window.alert('插入失败！');</script>");
            }
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstrumrntManagement.aspx");
        }
    }
}