<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CurrencyConverter.aspx.cs" Inherits="LabAss6.CurrencyConverter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 549px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Label ID="Label1" runat="server" Text="Convert:"></asp:Label>
            <asp:TextBox ID="txtMoney" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Chinese Yuan to Dollars."></asp:Label>
            <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="OK" Width="77px" />
        </div>
    </form>
</body>
</html>
