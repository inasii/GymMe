<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="GymMePSD.Views.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Information</title>
</head>
<body>
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
        <div>
            <asp:Panel ID="pnl_viewProfile" runat="server">
                <asp:Label ID="lbl_username" runat="server" Text="Username: "></asp:Label>
                <asp:Label ID="lbl_usernameValue" runat="server"></asp:Label><br />
                <asp:Label ID="lbl_email" runat="server" Text="Email: "></asp:Label>
                <asp:Label ID="lbl_emailValue" runat="server"></asp:Label><br />
                <asp:Label ID="lbl_gender" runat="server" Text="Gender: "></asp:Label>
                <asp:Label ID="lbl_genderValue" runat="server"></asp:Label><br />
                <asp:Label ID="lbl_dob" runat="server" Text="Date of Birth: "></asp:Label>
                <asp:Label ID="lbl_dobValue" runat="server"></asp:Label><br />
                <asp:Button ID="bt_editProfile" runat="server" Text="Edit Profile" OnClick="bt_editProfile_Click" /><br />
            </asp:Panel>

            <asp:Panel ID="pnl_editProfile" runat="server" Visible="False">
                <asp:Label ID="lbl_editUsername" runat="server" Text="Username: "></asp:Label>
                <asp:TextBox ID="txt_editUsername" runat="server"></asp:TextBox><br />
                <asp:Label ID="lbl_editEmail" runat="server" Text="Email: "></asp:Label>
                <asp:TextBox ID="txt_editEmail" runat="server"></asp:TextBox><br />
                <asp:Label ID="lbl_editGender" runat="server" Text="Gender: "></asp:Label>
                <asp:DropDownList ID="ddl_editGender" runat="server">
                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                </asp:DropDownList><br />
                <asp:Label ID="lbl_editDOB" runat="server" Text="Date of Birth: "></asp:Label>
                <asp:TextBox ID="txt_editDOB" runat="server"></asp:TextBox><br />
                <asp:Button ID="bt_updateProfile" runat="server" Text="Update Profile" OnClick="bt_updateProfile_Click" /><br />
                <asp:Button ID="bt_cancelEdit" runat="server" Text="Cancel" OnClick="bt_cancelEdit_Click" /><br />
            </asp:Panel>
         
            <asp:Panel ID="pnl_changePassword" runat="server">
                <asp:Label ID="lbl_oldPassword" runat="server" Text="Old Password: "></asp:Label>
                <asp:TextBox ID="txt_oldPassword" runat="server" TextMode="Password"></asp:TextBox><br />
                <asp:Label ID="lbl_newPassword" runat="server" Text="New Password: "></asp:Label>
                <asp:TextBox ID="txt_newPassword" runat="server" TextMode="Password"></asp:TextBox><br />
                <asp:Label ID="lbl_confirmNewPassword" runat="server" Text="Confirm New Password: "></asp:Label>
                <asp:TextBox ID="txt_confirmNewPassword" runat="server" TextMode="Password"></asp:TextBox><br />
                <asp:Button ID="bt_updatePassword" runat="server" Text="Update Password" OnClick="bt_updatePassword_Click" /><br />
            </asp:Panel>

            <asp:Label ID="lbl_message" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
