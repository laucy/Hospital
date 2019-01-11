using Hospital.Controllers;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital.Views.SystemManagement.Sickbed
{
    public partial class SickbedManage : System.Web.UI.Page
    {
        public List<Models.Sickbed> sickbedinfo;
        public string[] dename = new string[30];
        protected void Page_Load(object sender, EventArgs e)
        {
            sickbedinfo = Sickbed_C.Getinfobyrid("");
            for(int i = 0; i < sickbedinfo.Count; i++)
            {
                dename[i] = Department_C.DE_seekname(sickbedinfo[i].D_ID.ToString()).DE_Name;
            }
            if (!IsPostBack)
            {
                List<Department> de = Department_C.GetDepartmentName();
                this.denamein.DataSource = de;
                this.denamein.DataTextField = "DE_Name";
                this.denamein.DataBind();
            }
        }

        protected void search_Click(object sender, EventArgs e)
        {
            if (roomsearch.Value != "" )
            {
                sickbedinfo = Sickbed_C.Getinfobyrid(roomsearch.Value);
                if (sickbedinfo != null)
                {
                    for (int i = 0; i < sickbedinfo.Count; i++)
                    {
                        dename[i] = Department_C.DE_seekname(sickbedinfo[i].D_ID.ToString()).DE_Name;
                    }
                }
            }
            else if(departsearch.Value!="")
            {
                sickbedinfo = Sickbed_C.Getinfobydename(departsearch.Value);
                if (sickbedinfo != null)
                {
                    for (int i = 0; i < sickbedinfo.Count; i++)
                    {
                        dename[i] = Department_C.DE_seekname(sickbedinfo[i].D_ID.ToString()).DE_Name;
                    }
                }
            }
            else
            {
                sickbedinfo = Sickbed_C.Getinfobyrid("");
                if (sickbedinfo != null)
                {
                    for (int i = 0; i < sickbedinfo.Count; i++)
                    {
                        dename[i] = Department_C.DE_seekname(sickbedinfo[i].D_ID.ToString()).DE_Name;
                    }
                }
            }
        }

        protected void insert_Click(object sender, EventArgs e)
        {
            if(sickbedid.Text!="" && roomid.Text!=""&&denamein.Text!="" && avai.Text != "")
            {
                bool result = Sickbed_C.Insert(sickbedid.Text, roomid.Text, avai.Text, denamein.Text);
                if (result == true) {
                    Response.Write("<script language=javascript>window.alert('插入成功！');</script>");
                    sickbedid.Text = "";
                    roomid.Text = "";                    
                }
                else
                {
                    Response.Write("<script language=javascript>window.alert('插入失败！请重新检查信息是否正确！');</script>");
                }

            }
            else
            {
                Response.Write("<script language=javascript>window.alert('请将信息填写完整！');</script>");
            }
        }
    }
}