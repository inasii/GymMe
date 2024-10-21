<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="GymMePSD.Views.Order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order</title>
</head>
<body>
    <h1>Order Supplement</h1>
    <form id="form1" runat="server">
    <asp:Panel ID="navPanel" runat="server">
    <section id="navigationbar" class="button-container">
        <asp:PlaceHolder ID="customerMenu" runat="server" Visible="true">
            <asp:Button ID="btnHistory" runat="server" Text="History" PostBackUrl="~/Views/Transactions.aspx" />
            <asp:Button ID="btnProfile" runat="server" Text="Profile" PostBackUrl="~/Views/Profile.aspx" />
            <asp:Button ID="btnLogout" runat="server" Text="Logout" PostBackUrl="~/Views/Logout.aspx" />
        </asp:PlaceHolder>
        </section>
    </asp:Panel>
    
        <asp:GridView ID="OrderGV" runat="server" AutoGenerateColumns="False" OnRowCommand="SupplementGV_RowCommand" DataKeyNames="SupplementID">
            <Columns>
                <asp:BoundField DataField="SupplemetName" HeaderText="Name" />
                <asp:BoundField DataField="SupplementExpiryDate" HeaderText="Expiry Date" />
                <asp:BoundField DataField="SupplementPrice" HeaderText="Price" />
                <asp:BoundField DataField="SupplementTypeID" HeaderText="Type" />
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="QuantityTextBox" runat="server" Width="50px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="OrderButton" runat="server" CommandName="Order" CommandArgument='<%# Container.DataItemIndex %>'
                                Text="Order"/>
                        </ItemTemplate>
                    </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lbl_error" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
        <asp:Button ID="ClearCartButton" runat="server" Text="Clear Cart" OnClick="ClearCartButton_Click" />
        <asp:Button ID="CheckoutButton" runat="server" Text="Checkout" OnClick="CheckoutButton_Click" />
         <asp:GridView ID="CartGridView" runat="server" AutoGenerateColumns="False" Visible="false">
            <Columns>
                <asp:BoundField DataField="SupplementName" HeaderText="Name" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
