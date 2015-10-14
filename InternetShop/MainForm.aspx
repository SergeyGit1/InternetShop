<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="InternetShop.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label_message" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" style="text-align: center" Width="586px">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="name" HeaderText="Наименование" SortExpression="name" />
                <asp:BoundField DataField="category" HeaderText="Категория" SortExpression="category" />
                <asp:BoundField DataField="cost" HeaderText="Стоимость" SortExpression="cost" />
                <asp:CommandField ButtonType="Button" HeaderText="Купить?" SelectText="+" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [GoodsTable]"></asp:SqlDataSource>
        <br />
        <asp:Button ID="btn_basket" runat="server" OnClick="btn_basket_Click" Text="К корзине" />
    
    </div>
    </form>
</body>
</html>
