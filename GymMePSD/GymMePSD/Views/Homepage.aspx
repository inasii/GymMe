<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="GymMePSD.Views.Homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome To HomePage</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="navPanel" runat="server">
            <section id="navigationbar">
                <ul id="navBar">
                    <asp:PlaceHolder ID="customerMenu" runat="server" Visible="false">
                        <asp:Button ID="btnOrder" runat="server" Text="Order Supplement" PostBackUrl="Order.aspx" CssClass="navButton" />
                        <asp:Button ID="btnHistory" runat="server" Text="History" PostBackUrl="Transactions.aspx" CssClass="navButton" />
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="adminMenu" runat="server" Visible="false">
                        <asp:Button ID="btnHome" runat="server" Text="Home" PostBackUrl="Home.aspx" CssClass="navButton" />
                        <asp:Button ID="btnManageSupplement" runat="server" Text="Manage Supplement" PostBackUrl="ManageSupplement.aspx" CssClass="navButton" />
                        <asp:Button ID="btnOrderQueue" runat="server" Text="Order Queue" PostBackUrl="TransactionQueue.aspx" CssClass="navButton" />
                        <asp:Button ID="btnTransactionReport" runat="server" Text="Transaction Report" PostBackUrl="TransactionReport.aspx" CssClass="navButton" />
                    </asp:PlaceHolder>
                    <asp:Button ID="btnProfile" runat="server" Text="Profile" PostBackUrl="Profile.aspx" CssClass="navButton" />
                    <asp:Button ID="btnLogout" runat="server" Text="Logout" PostBackUrl="Logout.aspx" CssClass="navButton" />
                </ul>
            </section>
        </asp:Panel>
        <asp:Label ID="currentUser" runat="server" Text=""></asp:Label>
         <asp:PlaceHolder ID="adminMenu1" runat="server" Visible="false">
            <asp:GridView ID="customerList" runat="server" AutoGenerateColumns="true">
            </asp:GridView>
        </asp:PlaceHolder>
    </form>
</body>
</html>
