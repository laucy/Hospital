using Hospital.Controllers;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital.Views.LLogin
{
    public partial class LLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void but_login_Click(object sender, EventArgs e)
        {
            string id = UserID.Value.ToString();
            Session["uid"] = id;
            string psw = Password.Value.ToString();
            User user = User_C.U_Login(id, psw);
            if (user != null)
            {
                if (user.U_Role == "1")//管理员跳转的网页
                    Response.Redirect("/Views/Index/NurseIndex.aspx");
                else if (user.U_Role == "6")//病人跳转的首页
                    Response.Redirect("/Views/Index/PatientIndex.aspx");
                /*else if (employee.Position == 3)
                    Response.Redirect("/Views/Index/salesclerk_index.aspx");*/
            }
            else
                Response.Write("<script language=javascript>window.alert('账号或密码错误，请重新输入！');</script>");
        }
    }
}