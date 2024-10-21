<%@ Page Title ="Transaction Queue" Language="C#" AutoEventWireup="true" CodeBehind="transactionQueue.aspx.cs" Inherits="WebApplication2.view.transactionQueue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        Transaction Queue
    </title>
    <link rel ="stylesheet" href =" https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
</head>
<body>
    <form id="TQueue" runat="server">
        <div class="container my-5">
            <h1>
                Transaction Queue
            </h1>
            <asp:GridView ID="GVTransactions" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped" OnRowCommand="GVTransactions_RowCommand">
                <Columns>
                    <asp:BoundField DataField ="TransactionId" HeaderText ="ID" SortExpression="TransactionId" />
                    <asp:BoundField DataField ="TransactionDate" HeaderText ="Date" SortExpression="TransactionDate" />
                    <asp:BoundField DataField ="Status" HeaderText ="Status" SortExpression="Status" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="BtnHandle" runat="server" Text ="Handle Transaction" CssClass="btn btn-primary" UseSubmitBehavior ="false" CommandName="Handle" />
                        </ItemTemplate>

                    </asp:TemplateField>
                </Columns>
                </asp:GridView>
                <asp:Label ID ="LblError" runat ="server" Text="" CssClass="text-danger"></asp:Label>
        </div>
    </form>
</body>
</html>
