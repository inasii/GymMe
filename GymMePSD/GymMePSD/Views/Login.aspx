<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GymMePSD.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Login Page!</h2>
           <asp:Label ID="LabelError" runat="server" ForeColor="Red" Visible="True"></asp:Label>
            <br />
            <asp:Label ID="Username" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="Usernametxt" runat="server"></asp:TextBox>
            <br>
            <asp:Label ID="Password" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="Passwordtxt" runat="server" TextMode="Password"></asp:TextBox>
            <br>
            <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
            <br>
            <asp:CheckBox ID="CheckBoxRemem" runat="server" />
            <asp:Label ID="CheckboxRemember" runat="server" Text="Remember me?"></asp:Label>
            <br />
            <asp:Label ID="Account" runat="server" Text="Don't have Account?"></asp:Label>
             <a href="Register.aspx">Register</a>
        </div>
    </form>
</body>
</html>
