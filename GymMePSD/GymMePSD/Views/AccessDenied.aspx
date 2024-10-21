<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessDenied.aspx.cs" Inherits="GymMePSD.Views.Access_denied" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Access denied</h1>
            <asp:Button ID="GobackBTN" runat="server" Text="Go back" OnClick="GobackBTN_Click" />
        </div>
    </form>
</body>
</html>
