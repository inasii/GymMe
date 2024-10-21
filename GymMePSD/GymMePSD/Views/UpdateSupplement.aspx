<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateSupplement.aspx.cs" Inherits="GymMePSD.Views.UpdateSupplement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Update Supplement</h1>
            <asp:Label ID="Namelbl" runat="server" Text="Name :"></asp:Label>
            <asp:TextBox ID="NameTB" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="EDlbl" runat="server" Text="Expiry Date :"></asp:Label>
            <asp:TextBox ID="EDTB" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Pricelbl" runat="server" Text="Price :"></asp:Label>
            <asp:TextBox ID="PriceTB" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="TypeIDlbl" runat="server" Text="Type ID :"></asp:Label>
            <asp:TextBox ID="TypeIDTB" runat="server"></asp:TextBox>
            <br />

            <asp:Button ID="UpdateBTN" runat="server" Text="Update" OnClick="UpdateBTN_Click" />
            <asp:Button ID="GobackBTN" runat="server" Text="Go back" OnClick="GobackBTN_Click" />
        </div>
    </form>
</body>
</html>
