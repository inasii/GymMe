using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMePSD.Views
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["LoginCookie"] != null)
            {
                HttpCookie loginCookie = new HttpCookie("LoginCookie");
                loginCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(loginCookie);
            }

            Response.Redirect("~/Views/Login.aspx");
        }
    }
}