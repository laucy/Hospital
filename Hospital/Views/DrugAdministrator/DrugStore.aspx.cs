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
    public partial class DrugStore : System.Web.UI.Page
    {
        public List<Drug> drugs;
        public int i;
        protected void Page_Load(object sender, EventArgs e)
        {
            drugs = Drug_C.SelectFuzzy("");
        }

        protected void search_drug_Click(object sender, EventArgs e)
        {
            if(Drug_C.isExit(drug_name.Value)==true)
            drugs = Drug_C.SelectFuzzy(drug_name.Value);
            else
                Response.Write("<script language=javascript>window.alert('该药品不存在！');</script>");
        }
    }
}