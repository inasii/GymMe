using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMePSD.Views
{
    public partial class Access_denied : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GobackBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Homepage.aspx");
        }
    }
}