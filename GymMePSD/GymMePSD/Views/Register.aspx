<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GymMePSD.Views.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Register Page!</h1>
             <asp:Label ID="LabelError" runat="server" ForeColor="Red" Visible="True"></asp:Label>
            <div>
                <asp:Label ID="LabelUser" runat="server" Text="Username :"></asp:Label>
                <asp:TextBox ID="TextUser" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="LabelEmail" runat="server" Text="Email :"></asp:Label>
                <asp:TextBox ID="TextEmail" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="LabelGender" runat="server" Text="Gender :"></asp:Label>
                <asp:DropDownList ID="DropDownGender" runat="server">
                     <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="Male">Male</asp:ListItem>
                    <asp:ListItem Value="Female">Female</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <asp:Label ID="LabelPassword" runat="server" Text="Password :" ></asp:Label>
                <asp:TextBox ID="TextPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div>
      
                <asp:Label ID="LabelConfPassword" runat="server" Text="Confirmation Password :"></asp:Label>
                <asp:TextBox ID="TextConfPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div>
                
                <asp:Label ID="LabelDOB" runat="server" Text="Date of Birth :"></asp:Label>
                <asp:TextBox ID="TextDOB" runat="server" TextMode="Date"></asp:TextBox>
            </div>
            <asp:Button ID="ButtonRegister" runat="server" Text="Register" OnClick="ButtonRegister_Click" />
        </div>
        <div>
            <asp:Label ID="Accountl" runat="server" Text="have an Account?"></asp:Label>
             <a href="Login.aspx">Login</a>
        </div>
    </form>
</body>
</html>
