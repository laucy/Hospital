using Hospital.Controllers;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital.Views.Index
{
    public partial class PatientIndex : System.Web.UI.Page
    {
        public List<Patient> patients;
        public string sex;
        protected void Page_Load(object sender, EventArgs e)
        {
            string patientid=null;
            if (patientid != null) {
                patientid = Session["uid"].ToString();
                patients = Patient_C.GetPatientinformation(patientid);
                if (patients[0].P_Sex == "男")
                    sex = "先生";
                else
                    sex = "女士";
            }
            
        }
    }
}