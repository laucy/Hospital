using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospital.Models;
using Hospital.Controllers;

namespace Hospital.Views.DrugAdministrator
{
    public partial class DrugIn : System.Web.UI.Page
    {
        public List<Drug> drugs;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DrugIn_Click(object sender, EventArgs e)
        {
            int store = Drug_C.GetDrugStore(Convert.ToInt32(drug_ID.Value));
            store += Convert.ToInt32(drugin_number.Value);
            if (Drug_C.UpdateDrug(drug_ID.Value, store) == true)
            {
                Response.Write("<script language=javascript>window.alert('入库成功！');</script>");
            }
            else
                Response.Write("<script language=javascript>window.alert('入库成功！');</script>");
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../Views/Index/PharmacistIndex.aspx");
        }

        protected void Search_Drug_Click(object sender, EventArgs e)
        {
            bool l;
            int i;
            if (int.TryParse(drug_ID.Value, out i) == false)
                Response.Write("<script language=javascript>window.alert('药品ID输入格式不正确！');</script>");
            else
            {
                l = Drug_C.ExistDrug(Convert.ToInt32(drug_ID.Value));
                if (l == true)
                {
                    drugs = Drug_C.Select(drug_ID.Value);
                    drug_Name.Value = drugs[0].D_Name;
                    drug_Standard.Value = drugs[0].D_Standard;
                    drug_PurchasingPrice.Value = Convert.ToString(drugs[0].D_PurchasingPrice);
                    drug_SellingPrice.Value = Convert.ToString(drugs[0].D_SellingPrice);
                }
                else
                    Response.Write("<script language=javascript>window.alert('该药品不存在，请先登记！');</script>");
            }
        }
    }
}