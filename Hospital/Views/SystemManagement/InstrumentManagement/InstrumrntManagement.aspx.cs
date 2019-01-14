using Hospital.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospital.Models;


namespace Hospital.Views.SystemManagement.InstrumentManagement
{
    public partial class InstrumrntManagement : System.Web.UI.Page
    {
        public List<Instrument> instruments;
        public int i;
        protected void Page_Load(object sender, EventArgs e)
        {
            instruments=Instrument_C.SelectFuzzy("");
        }

        protected void search_Click(object sender, EventArgs e)
        {
            if (iidtext.Value == "")
                instruments=Instrument_C.SelectFuzzy(inametext.Value);
            else
                instruments=Instrument_C.Select(iidtext.Value);
        }

        protected void insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertInstrument.aspx");
        }
    }
}