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
                if (user.U_Role == "1")//护士跳转的网页1
                    Response.Redirect("/Views/Index/Nurse1Index.aspx");
                else if (user.U_Role == "2")//财务人员跳转的首页2
                    Response.Redirect("/Views/Index/CashierIndex.aspx");
                else if (user.U_Role == "3")//医生跳转的首页3
                    Response.Redirect("/Views/Index/DoctorIndex.aspx");
                else if (user.U_Role == "4")//药品管理员跳转的首页4
                    Response.Redirect("/Views/Index/PharmacistIndex.aspx");
                else if (user.U_Role == "5")//系统管理员跳转的首页5
                    Response.Redirect("/Views/Index/Admin.aspx");
                else if (user.U_Role == "6")//病人跳转的首页
                    Response.Redirect("/Views/Index/PatientIndex.aspx");
            }
            else
                Response.Write("<script language=javascript>window.alert('账号或密码错误，请重新输入！');</script>");
        }
    }
}