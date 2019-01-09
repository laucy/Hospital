using Hospital.Controllers;
using System;

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
            int i;
            float j;
            if (int.TryParse(drug_ID.Value, out i) == false)
                Response.Write("<script language=javascript>window.alert('药品ID输入格式不正确！');</script>");
            else
            {
                s = Drug_C.ExistDrug(Convert.ToInt32(drug_ID.Value));
                if (s == true)
                    Response.Write("<script language=javascript>window.alert('该药品已存在！');</script>");
                else
                {
                    if (float.TryParse(drug_PurchasingPrice.Value, out j) == false)
                        Response.Write("<script language=javascript>window.alert('该药品进价输入格式不正确！');</script>");
                    else
                    {
                        if (float.TryParse(drug_SellingPrice.Value, out j) == false)
                            Response.Write("<script language=javascript>window.alert('该药品售价输入格式不正确！');</script>");
                        else
                        {
                            l = Drug_C.Insert(Convert.ToInt32(drug_ID.Value), drug_Name.Value, drug_Standard.Value, Convert.ToSingle(drug_PurchasingPrice.Value), Convert.ToSingle(drug_SellingPrice.Value));
                            if (l == true)
                                Response.Write("<script language=javascript>window.alert('登记成功！');</script>");
                            else
                                Response.Write("<script language=javascript>window.alert('登记失败！');</script>");
                        }
                    }
                }
            }
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../Views/Index/PharmacistIndex.aspx");
        }
    }
}