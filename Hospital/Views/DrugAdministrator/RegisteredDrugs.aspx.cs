using Hospital.Controllers;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital.Views.DrugAdministrator
{
    public partial class RegisteredDrugs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void register_Click(object sender, EventArgs e)
        {
            bool s,l;
            s=Drug_C.ExistDrug(Convert.ToInt32(drug_ID.Value));
            if(s==true)
                Response.Write("<script language=javascript>window.alert('该药品已存在！');</script>");
            else
            {
                l=Drug_C.Insert(Convert.ToInt32(drug_ID.Value),drug_Name.Value,drug_Standard.Value, Convert.ToSingle(drug_PurchasingPrice.Value),Convert.ToSingle(drug_SellingPrice.Value));
                if(l==true)
                    Response.Write("<script language=javascript>window.alert('登记成功！');</script>");
                else
                    Response.Write("<script language=javascript>window.alert('登记失败！');</script>");
            }
        }

        protected void cancel_Click(object sender, EventArgs e)
        {

        }
    }
}