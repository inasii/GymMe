using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GymMePSD.Controller;
using GymMePSD.Model;
using WebApplication2.controller;
using WebApplication2.module;

namespace WebApplication2.view
{
    public partial class transactionQueue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                refreshTransactionQueue();
            }
        }

        private void refreshTransactionQueue()
        {
            response<List<TransactionHeader>> response = transactionController.getAllHeader();

            if (response.isSuccess)
            {
                GVTransactions.DataSource = response.resultData;
                GVTransactions.DataBind();
            }
        }

        protected void GVTransactions_RowCommand(object sender, GridViewCommandEventArgs z)
        {
            if (z.CommandName == "Handle")
            {
                int rowIndex = Convert.ToInt32(z.CommandArgument);


                Control sourceControl = z.CommandSource as Control;
                GridViewRow row = GVTransactions.Rows[rowIndex]; // sourceControl.NamingContainer  as GridViewRow;
                int index = row.RowIndex;

                int transactionId = Convert.ToInt32(row.Cells[0].Text);
                int id = int.Parse(GVTransactions.Rows[index].Cells[0].Text);

                response<TransactionHeader> response = transactionController.updateStatus(id, "Handled");

                LblError.Text = response.Message;
                LblError.ForeColor = (response.isSuccess) ? System.Drawing.Color.Brown : System.Drawing.Color.Beige;

                refreshTransactionQueue();
            }
        }
    }
}