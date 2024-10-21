using GymMePSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMePSD.Views
{
    public partial class Profile : System.Web.UI.Page
    {
        DatabaseGYMEntities5 db = new DatabaseGYMEntities5();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserProfile();
            }
        }

        private void LoadUserProfile()
        {
            string username = Session["Username"]?.ToString();
            var user = db.MsUsers.SingleOrDefault(u => u.UserName == username);

            if (user != null)
            {
                lbl_usernameValue.Text = user.UserName;
                lbl_emailValue.Text = user.UserEmail;
                lbl_genderValue.Text = user.UserGender;
                lbl_dobValue.Text = user.UserDOB.ToString("yyyy-MM-dd");

                txt_editUsername.Text = user.UserName;
                txt_editEmail.Text = user.UserEmail;
                ddl_editGender.SelectedValue = user.UserGender;
                txt_editDOB.Text = user.UserDOB.ToString("yyyy-MM-dd");
            }
            else
            {
                lbl_message.Text = "User not found.";
            }
        }

        protected void bt_editProfile_Click(object sender, EventArgs e)
        {
            pnl_viewProfile.Visible = false;
            pnl_editProfile.Visible = true;
        }

        protected void bt_updateProfile_Click(object sender, EventArgs e)
        {
            string username = Session["Username"]?.ToString();
            var user = db.MsUsers.SingleOrDefault(u => u.UserName == username);

            if (user != null)
            {
                user.UserName = txt_editUsername.Text;
                user.UserEmail = txt_editEmail.Text;
                user.UserGender = ddl_editGender.SelectedValue;
                user.UserDOB = DateTime.Parse(txt_editDOB.Text);

                db.SaveChanges();
                lbl_message.Text = "Profile updated successfully.";

                LoadUserProfile();
                pnl_viewProfile.Visible = true;
                pnl_editProfile.Visible = false;
            }
            else
            {
                lbl_message.Text = "User not found.";
            }
        }

        protected void bt_cancelEdit_Click(object sender, EventArgs e)
        {
            pnl_viewProfile.Visible = true;
            pnl_editProfile.Visible = false;
        }

        protected void bt_updatePassword_Click(object sender, EventArgs e)
        {
            string username = Session["Username"]?.ToString();
            var user = db.MsUsers.SingleOrDefault(u => u.UserName == username);

            if (user != null)
            {
                string oldPassword = txt_oldPassword.Text;
                string newPassword = txt_newPassword.Text;
                string confirmNewPassword = txt_confirmNewPassword.Text;

                if (user.UserPassword == oldPassword)
                {
                    if (newPassword == confirmNewPassword)
                    {
                        user.UserPassword = newPassword;
                        db.SaveChanges();
                        lbl_message.Text = "Password updated successfully.";
                    }
                    else
                    {
                        lbl_message.Text = "New password and confirm new password do not match.";
                    }
                }
                else
                {
                    lbl_message.Text = "Old password is incorrect.";
                }
            }
            else
            {
                lbl_message.Text = "User not found.";
            }

        }
    }
}