using GymMePSD.Controller;
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
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserRole"] == null)
                {
                    
                    if (Request.Cookies["LoginCookie"] != null)
                    {
                        string username = Request.Cookies["LoginCookie"]["Username"];
                        string password = Request.Cookies["LoginCookie"]["Password"];

                        if (UserController.LoginUser(username, password))
                        {
                            MsUser user = UserRepository.GetUserByUsername(username);
                            if (user != null)
                            {
                                
                                Session["UserRole"] = user.UserRole;
                                Session["Username"] = user.UserName;
                            }
                            else
                            {
                               
                                Response.Redirect("~/Views/Login.aspx");
                            }
                        }
                        else
                        {
                            
                            Response.Redirect("~/Views/Login.aspx");
                        }
                    }
                    else
                    {
                    
                        Response.Redirect("~/Views/Login.aspx");
                    }
                }

                
                string userRole = Session["UserRole"] as string;
                string userName = Session["UserName"] as string;

                //Page.Header.Title = "Welcome To Homepage " + userName;

                currentUser.Text = "Hello, " + userName;

                if (userRole == "Customer")
                {
                    customerMenu.Visible = true;
                    adminMenu.Visible = false;
                }
                else if (userRole == "Admin")
                {
                    adminMenu.Visible = true;
                    customerMenu.Visible = false;
                    List<MsUser> customers = UserRepository.GetAllUsers();
                    customerList.DataSource = customers;
                    customerList.DataBind();
                }
            }
        }
    }
}