<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="GymMePSD.Views.History" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Transaction History</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Transaction History</h2>
            <asp:GridView ID="gv_transactions" runat="server" AutoGenerateColumns="False" OnRowCommand="gv_transactions_RowCommand" OnSelectedIndexChanged="gv_transactions_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
                    <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" />
                    <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="bt_viewDetails" runat="server" Text="View Details" CommandName="ViewDetails" CommandArgument='<%# Eval("TransactionID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
