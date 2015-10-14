<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Basket.aspx.cs" Inherits="InternetShop.Basket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: medium;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        Your order<br />
        <br />
        <asp:GridView ID="GridView2" runat="server" Width="611px">
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [name], [category], [cost] FROM [GoodsTable]"></asp:SqlDataSource>
        <br />
        <asp:Button ID="Buy" runat="server" OnClick="Buy_Click" Text="Оплатить" />
        <br />
        <br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="javascript:history.go(-1)">Назад</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>
