<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageSupplement.aspx.cs" Inherits="GymMePSD.Views.ManageSupplement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Manage Supplement</h1>
        <asp:Panel ID="navPanel" runat="server">
        <section id="navigationbar" class="button-container">
             <asp:PlaceHolder ID="adminMenu" runat="server" Visible="true">
                 <asp:Button ID="btnHome" runat="server" Text="Home" PostBackUrl="Home.aspx" CssClass="navButton" />
                 <asp:Button ID="btnTransactionQueue" runat="server" Text="Transaction Queue" PostBackUrl="TransactionQueue.aspx"  />
                 <asp:Button ID="btnTransactionReport" runat="server" Text="Transaction Report" PostBackUrl="TransactionReport.aspx" />
             </asp:PlaceHolder>
        </section>
        </asp:Panel>
        <div>
            <asp:GridView ID="SupplementGV" runat="server" AutoGenerateColumns="False" OnRowDeleting="SupplementGV_RowDeleting" OnRowEditing="SupplementGV_RowEditing">
                <Columns>
                    <asp:BoundField DataField="SupplementID" HeaderText="Supplement ID" SortExpression="SupplementID" />
                    <asp:BoundField DataField="SupplemetName" HeaderText="Supplement Name" SortExpression="SupplementName" />
                    <asp:BoundField DataField="SupplementExpiryDate" HeaderText="Expiry Date" SortExpression="SupplementExpiryDate" />
                    <asp:BoundField DataField="SupplementPrice" HeaderText="Price" SortExpression="SupplementPrice" />
                    <asp:BoundField DataField="SupplementTypeID" HeaderText="Type ID" SortExpression="SupplementTypeID" />

                    <asp:CommandField ShowCancelButton="False" ShowEditButton="True">
                    </asp:CommandField>
                    <asp:CommandField ShowDeleteButton="True" ButtonType="Button"></asp:CommandField>
                </Columns>

            </asp:GridView>
        </div>
        <asp:Button ID="InsertBtn" runat="server" Text="Insert new supplement"  OnClick="InsertBtn_Click"/>
    </form>
</body>
</html>