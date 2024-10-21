<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="GymMePSD.Views.Report" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" />
            <asp:Label ID="LblError" runat="server" foreColor="Red" Visible="false" ></asp:Label>
        </div>
    </form>
</body>
</html>
