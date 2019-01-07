using Hospital.Controllers;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital.Views.PatientSearch.PatientCaseSearch
{
    public partial class PatientCaseSearch : System.Web.UI.Page
    {
        public List<Patient> patients;
        Employee employeedoctor;
        List<Case> cases;
        public string sex;
        protected void Page_Load(object sender, EventArgs e)
        {
            string patientid =Session["uid"].ToString();
            patients = Patient_C.GetPatientinformation(patientid);
            if (patients[0].P_Sex == "男")
                sex = "先生";
            else
                sex = "女士";
            cases = Case_C.GetCaseinformation(patientid);
            string employeeid = cases[0].E_ID.ToString();
            employeedoctor = Employee_C.SeekDep(employeeid);
            pcname.Value = patients[0].P_Name;
            pcage.Value = patients[0].P_Age.ToString();
            pcgender.Value = patients[0].P_Sex;
            pcdoctor.Value = employeedoctor.E_Name;
            Complain1.Value = cases[0].C_Complain;
            Diagnose1.Value = cases[0].C_Diagnose;
            Advice1.Value = cases[0].C_Advice;
        }
    }
}