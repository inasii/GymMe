using GymMePSD.Controller;
using GymMePSD.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace GymMePSD.Views
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            string username = TextUser.Text.Trim();
            string email =  TextEmail.Text.Trim();
            string gender = DropDownGender.SelectedValue;
            string role = "Customer";
            string password = TextPassword.Text.Trim();
            string Confpassword = TextConfPassword.Text.Trim();
            DateTime DOB;

          
            if (string.IsNullOrEmpty(username))
            {
                LabelError.Text = "Username cannot be empty.";
                return;
            }
            else if (username.Length < 5 || username.Length > 15 || !username.All(char.IsLetterOrDigit))
            {
                LabelError.Text = "Username must be between 5 and 15 alphanumeric characters.";
                return;
            }

    
            if (string.IsNullOrEmpty(email))
            {
                LabelError.Text = "Email cannot be empty.";
                return;
            }
            else if (!email.EndsWith(".com", StringComparison.OrdinalIgnoreCase))
            {
                LabelError.Text = "Email must end with '.com'.";
                return;
            }

       
            if (string.IsNullOrEmpty(gender))
            {
                LabelError.Text = "Gender must be chosen.";
                return;
            }

        
            if (string.IsNullOrEmpty(password))
            {
                LabelError.Text = "Password cannot be empty.";
                return;
            }
            else if (password != Confpassword)
            {
                LabelError.Text = "Password and Confirm Password must match.";
                LabelError.Text = "Password and Confirm Password must match.";
                return;
            }
            else if (!password.All(char.IsLetterOrDigit))
            {
                LabelError.Text = "Password must be alphanumeric.";
                return;
            }

            if (!DateTime.TryParse(TextDOB.Text, out DOB))
            {
                LabelError.Text = "Invalid date format. Please enter a valid date.";
                return;
            }

            bool isUserRegistered = UserController.CreateUser(username, email, DOB, gender, role, password);
            if (isUserRegistered)
            {
                Response.Redirect("~/Views/Login.aspx");
            }


        }
    }

    }