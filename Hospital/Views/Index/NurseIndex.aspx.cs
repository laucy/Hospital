using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospital.Models;
using Hospital.Controllers;
using System.Web.Services;

namespace Hospital.Views.Index
{
    public partial class NurseIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //加载病床信息
                List<Sickbed> sb_list = Sickbed_C.SickBed_Info();
                int i = 0;
                foreach (Sickbed sb in sb_list)
                {
                    //Response.Write("<script languge='javascript'>alert('病床信息');</script>");
                    Patient patient = Patient_C.GetpInfo_bybed(sb.S_ID.ToString());
                    if (patient == null)
                    {
                        patient = new Patient();
                        patient.P_Name = "*";
                    }
                    string dename = Department_C.DE_seekname(sb.DE_ID.ToString()).DE_Name;
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript" + i, "<script type='text/javascript'>AddTable('" + sb.R_ID + "','" + dename + "','" + sb.S_ID + "','" + patient.P_Name + "','" + sb.S_Bool + "');</script>");
                    i++;
                }
            }
        }
        [WebMethod]
        public static string Distribute(string sid, string pid)
        {
            string cid =Case_C.GetCaseinformation(pid)[0].C_ID.ToString();
            if (Sickbed_C.DistributeBed(sid, cid))
                return "1";
            return "0";
               
        }

        protected void search_Click(object sender, EventArgs e)
        {
            Response.Write("<script languge='javascript'>alert('"+ Patient_ID.Value + "');</script>");
            List<Patient> patients = Patient_C.GetPatientinformation(Patient_ID.Value);
            pname.Value = patients[0].P_Name;
            patientage.Value = patients[0].P_Age.ToString();
            patientsex.Value = patients[0].P_Sex;
            pphone.Value = patients[0].P_Phone;
            List<Case> cases = Case_C.GetCaseinformation(Patient_ID.Value);
            List<Employee> employees = Employee_C.Select(cases[0].E_ID.ToString());
            Department depart=Department_C.DE_seekname(employees[0].DE_ID.ToString());
            pdoctor.Value = employees[0].E_Name;
            pdepart.Value = depart.DE_Name;
            List<Sickbed> sb_list = Sickbed_C.SickBedInfobyde(depart.DE_ID.ToString());
            int i = 0;
            foreach (Sickbed sb in sb_list)
            {               
                Patient patient = Patient_C.GetpInfo_bybed(sb.S_ID.ToString());
                if (patient == null)
                {
                    patient = new Patient();
                    patient.P_Name = "*";
                }
                string dename = Department_C.DE_seekname(sb.DE_ID.ToString()).DE_Name;
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript" + i, "<script type='text/javascript'>AddTable('" + sb.R_ID + "','" + dename + "','" + sb.S_ID + "','" + patient.P_Name + "','" + sb.S_Bool + "');</script>");
                i++;
            }

        }
    }
}