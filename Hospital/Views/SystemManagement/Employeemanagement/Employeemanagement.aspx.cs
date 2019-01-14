using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospital.Models;
using Hospital.Controllers;

namespace Hospital.Views.SystemManagement.Employeemanagement
{
    public partial class Employeemanagement : System.Web.UI.Page
    {
        public List<Employee> employees;
        public int i;
        protected void Page_Load(object sender, EventArgs e)
        {
            employees=Employee_C.SelectFuzzy("");
        }

        protected void search_Click(object sender, EventArgs e)
        {
            if (eidtext.Value == "")
                employees = Employee_C.SelectFuzzy(enametext.Value);
            else
                employees = Employee_C.Select(eidtext.Value);
        }

        protected void insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertEmployee.aspx");
        }
    }
}