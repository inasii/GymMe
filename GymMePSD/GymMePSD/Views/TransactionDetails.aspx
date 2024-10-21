<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="transactionDetails.aspx.cs" Inherits="WebApplication2.view.transactionDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        Transaction Details
    </title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>
                Transaction Details
            </h1>
            <asp:GridView ID="gridViewTransactionDetails" runat ="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped">
                <Columns>
                    <asp:BoundField DataField ="TransactionId" HeaderText ="Transaction ID" />
                    <asp:BoundField DataField ="SupplementName" HeaderText ="Supplement ID" />
                    <asp:BoundField DataField ="Quantity" HeaderText ="Quantity" />
                    <asp:BoundField DataField ="SupplementPrice" HeaderText ="Supplement Price" />
                    <asp:BoundField DataField ="Total" HeaderText ="Total Amount" />

                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
