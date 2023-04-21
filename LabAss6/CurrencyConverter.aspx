<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CurrencyConverter.aspx.cs" Inherits="LabAss6.CurrencyConverter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-color:#808000">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Convert:"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Chinese Yuan to Dollars."></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="OK" OnClick="Button1_Click" />
        </div>
        <div>
            <br />
            <asp:Label ID="Label3" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
