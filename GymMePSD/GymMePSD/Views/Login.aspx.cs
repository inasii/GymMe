using GymMePSD.Controller;
using GymMePSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMePSD.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["LoginCookie"] != null)
                {
                    string username = Request.Cookies["LoginCookie"]["Username"];
                    string password = Request.Cookies["LoginCookie"]["Password"];

                    if (UserController.LoginUser(username, password))
                    {
                        MsUser user = UserController.GetAllUsers().FirstOrDefault(u => u.UserName == username);
                        if(user != null)
                        {
                            Session["UserRole"] = user.UserRole;
                            Session["UserName"] = user.UserName;
                            Response.Redirect("~/Views/Homepage.aspx");
                        }
                        
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = Usernametxt.Text;
            string password = Passwordtxt.Text;
            bool rememberMe = CheckBoxRemem.Checked;
            bool isLoginUser = UserController.LoginUser(username, password);

            LabelError.Text = string.Empty;

            if (string.IsNullOrEmpty(username))
            {
                LabelError.Text = "Username cannot be empty.";
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                LabelError.Text = "Password cannot be empty.";
                return;
            }



            if (isLoginUser)
            {
                if (rememberMe)
                {
                    HttpCookie cookie = new HttpCookie("LoginCookie");
                    cookie.Values["Username"] = username;
                    cookie.Values["Password"] = password;
                    cookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(cookie);
                }
                Response.Redirect("~/Views/HomePage.aspx");
            }
            else
            {
                LabelError.Text = "Incorrect username or password.";
            }




        }
    }
}