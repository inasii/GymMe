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
    public partial class UpdateSupplement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request["ID"]);
                MsSupplement tobeupdated = SupplementRespository.GetSupplementByID(id);
                NameTB.Text = tobeupdated.SupplemetName;
                EDTB.Text = tobeupdated.SupplementExpiryDate.ToString();
                PriceTB.Text = tobeupdated.SupplementPrice.ToString();
                TypeIDTB.Text = tobeupdated.SupplementTypeID.ToString();
            }

        }

        protected void UpdateBTN_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request["ID"]);
            string name = NameTB.Text;
            DateTime Date = Convert.ToDateTime(EDTB.Text);
            int Price = Convert.ToInt32(PriceTB.Text);
            int TypeID = Convert.ToInt32(TypeIDTB.Text);

            MsSupplement tobeupdated = SupplementRespository.GetSupplementByID(id);
            tobeupdated.SupplemetName = name;
            tobeupdated.SupplementExpiryDate = Date;
            tobeupdated.SupplementPrice = Price;
            tobeupdated.SupplementTypeID = TypeID;
            SupplementRespository.updateSupplement();
        }

        protected void GobackBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageSupplement.aspx");
        }
    }
}