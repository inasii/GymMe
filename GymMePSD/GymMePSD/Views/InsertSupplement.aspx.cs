using GymMePSD.Factories;
using GymMePSD.Handler;
using GymMePSD.Model;
using GymMePSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMePSD.Views
{
    public partial class InsertSupplement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitBTN_Click(object sender, EventArgs e)
        {
            // Response<ManageSupplement> response = supplementHandler.AddSupplement(supplementId, supplementName, supplementExpiryDate, supplementPrice, supplementTypeID);
            int supplementId = Convert.ToInt32(SupplementIDTB.Text);
            String Supplementname = NameTB.Text;
            DateTime supplementDate = Convert.ToDateTime(EDTB.Text);
            int SupplementPrice = Convert.ToInt32(PriceTB.Text);
            int supplementTypeID = Convert.ToInt32(TypeIDTB.Text);
            MsSupplement newSupplement = SupplementFactory.Create(supplementId, Supplementname, supplementDate, SupplementPrice, supplementTypeID);

            SupplementRespository.AddSupplement(supplementId, Supplementname, supplementDate, SupplementPrice, supplementTypeID);

            Response.Redirect("~/Views/ManageSupplement.aspx");
        }
        protected void GobackBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageSupplement.aspx");
        }
    }
}