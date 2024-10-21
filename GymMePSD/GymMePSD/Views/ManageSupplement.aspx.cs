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
    public partial class ManageSupplement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Session["UserName"] as string;
            if (string.IsNullOrEmpty(username))
            {
                Response.Redirect("~/Views/Login.aspx");
            }

            string userRole = Session["UserRole"] as string;
            if (userRole != "Admin")
            {
                Response.Redirect("~/Views/AccessDenied.aspx");
            }

            List<MsSupplement> supplements = SupplementRespository.GetAll();
            SupplementGV.DataSource = supplements;
            SupplementGV.DataBind();

        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertSupplement.aspx");
        }

        protected void SupplementGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow Row = SupplementGV.Rows[e.RowIndex];
            int id = Convert.ToInt32(Row.Cells[0].Text.ToString());
            MsSupplement ToBeDeleted = SupplementRespository.GetSupplementByID(id);
            SupplementRespository.deleteSupplement(id);
            Response.Redirect("~/Views/ManageSupplement.aspx");
        }

        protected void SupplementGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow Row = SupplementGV.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(Row.Cells[0].Text.ToString());
            Response.Redirect("~/Views/UpdateSupplement.aspx?ID=" + id);
        }
        protected void Supplement_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow Row = SupplementGV.Rows[e.RowIndex];
            int id = Convert.ToInt32(Row.Cells[0].Text.ToString());
            Response.Redirect("~/Views/UpdateSupplement.aspx?ID=" + id);
        }

    }
}