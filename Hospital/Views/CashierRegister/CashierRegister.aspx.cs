﻿using Hospital.Controllers.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital.Views.CashierRegister
{
    public partial class CashierRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cashbutton_Click(object sender, EventArgs e)
        {
            bool result = Patient_C.Insert(pname.Value,psex.Value,ppage.Value, pphone.Value);           
            if (result)
            {

                Response.Write("<script language=javascript>window.alert('挂号成功');</script>");              
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
    }
}