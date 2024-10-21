using GymMePSD.Model;
using GymMePSD.Repositories;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Util;
using WebApplication2.handler;

namespace GymMePSD.Views
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userRole = Session["UserRole"] as string;
            string userName = Session["UserName"] as string;

            if (userRole != "Customer")
            {
                Response.Redirect("~/Views/AccessDenied.aspx");
            }

            if (!IsPostBack)
            {
                List<MsSupplement> supplements = SupplementRespository.GetAll();
                OrderGV.DataSource = supplements;
                OrderGV.DataKeyNames = new string[] { "SupplementID" };
                OrderGV.DataBind();
            }
            
        }

        protected void SupplementGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Order")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                if(rowIndex >= 0 && rowIndex < OrderGV.Rows.Count)
                {
                    GridViewRow row = OrderGV.Rows[rowIndex];
                    int supplementId = Convert.ToInt32(OrderGV.DataKeys[rowIndex].Value);
                    TextBox quantityTextBox = (TextBox)row.FindControl("QuantityTextBox");
                    int quantity;
                    if (int.TryParse(quantityTextBox.Text, out quantity) && quantity > 0)
                    {
                        AddToCart(supplementId, quantity);
                    }
                    else
                    {
                        lbl_error.Text = "Invalid quantity. Please enter a valid quantity.";
                        lbl_error.Visible = true;
                    }
                } 
            }
        }
        private void AddToCart(int supplementId, int quantity)
        {
            string userName = Session["UserName"] as string;
            MsUser user = UserRepository.GetUserByUsername(userName);

            if (user != null)
            {
                CartRepository.AddToCart(user.UserID, supplementId, quantity);
            }
        }

        protected void ClearCartButton_Click(object sender, EventArgs e)
        {
            string userName = Session["UserName"] as string;
            MsUser user = UserRepository.GetUserByUsername(userName);

            if (user != null)
            {
                CartRepository.ClearCart(user.UserID);
            }
        }

        protected void CheckoutButton_Click(object sender, EventArgs e)
        {
            string userName = Session["UserName"] as string;
            MsUser user = UserRepository.GetUserByUsername(userName);

            if (user != null)
            {
                List<MsCart> cartItems = CartRepository.GetCartItems(user.UserID);
                if (cartItems != null && cartItems.Count > 0)
                {
                    var headerResponse = TransactionHandlers.addHeader(user.UserID, DateTime.Now, "Unhandled");

                    if (headerResponse.isSuccess)
                    {
                        int transactionId = headerResponse.resultData.TransactionID;
                        foreach (var item in cartItems)
                        {
                            var detailResponse = TransactionHandlers.addDetail(transactionId, item.SupplementID, item.Quantity);
                            if (!detailResponse.isSuccess)
                            {
                                lbl_error.Text = "Failed to add transaction detail: " + detailResponse.Message;
                                lbl_error.Visible = true;
                                return;
                            }
                        }

                        CartRepository.ClearCart(user.UserID);
                        Response.Redirect("~/Views/TransactionSuccess.aspx");
                    }
                    else
                    {
                        lbl_error.Text = "Failed to create transaction header: " + headerResponse.Message;
                        lbl_error.Visible = true;
                    }
                }
                else
                {
                    lbl_error.Text = "Your cart is empty. Please add items to your cart before checking out.";
                    lbl_error.Visible = true;
                }
            }
        }
    }
}