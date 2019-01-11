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
    public partial class DrugOut : System.Web.UI.Page
    {
        public List<Prescript> prescripts;
        public int j;
        protected void Page_Load(object sender, EventArgs e)
        {
            prescripts = Prescript_C.SelectPrescript(39);
        }

        protected void 查找_Click(object sender, EventArgs e)
        {
            prescripts = Prescript_C.SelectPrescript(Convert.ToInt32(patient_ID.Value));
        }

        protected void Drugout_Click(object sender, EventArgs e)
        {
            if(Prescript_C.DrugOUT(prescripts)==true)
                Response.Write("<script language=javascript>window.alert('出库成功！');</script>");
            else
                Response.Write("<script language=javascript>window.alert('出库失败！');</script>");
        }
    }
}