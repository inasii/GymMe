using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GymMePSD.Model;

namespace WebApplication2.view
{
    public partial class transactionDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindTransactionDetails();
            }
        }

        private void bindTransactionDetails()
        {
            using (var context = new DatabaseGYMEntities5())
            {
                var transactionDetails = (from td in context.TransactionDetails
                                          join msp in context.MsSupplements on td.SupplementID equals msp.SupplementID
                                          join th in context.TransactionHeaders on td.TransactionID equals th.TransactionID
                                          select new
                                          {
                                              TransactionID = td.TransactionID,
                                              SupplementName = msp.SupplemetName,
                                              Quantity = td.Quantity,
                                              SupplementPrice = msp.SupplementPrice,
                                              totalAmount = td.Quantity * msp.SupplementPrice
                                          }).ToList();


                gridViewTransactionDetails.DataSource = transactionDetails;
                gridViewTransactionDetails.DataBind();
            }
        }
    }
}