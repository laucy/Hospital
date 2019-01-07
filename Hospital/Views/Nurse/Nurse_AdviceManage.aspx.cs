using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital.Views.Nurse
{
    public partial class Nurse_AdviceManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            show_depart.InnerHtml=Session["dep"].ToString();

        }
    }
}