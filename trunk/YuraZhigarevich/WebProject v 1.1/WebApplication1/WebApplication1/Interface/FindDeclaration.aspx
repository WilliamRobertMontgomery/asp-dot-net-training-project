<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FindDeclaration.aspx.cs" Inherits="WebApplication1.Interface.FindDeclaration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-size: x-large;
            font-family: cursive;
        }
        .style2
        {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center" class="style1">
    
        Просмотр объявлений</div>
    <p style="text-align: center">
        <span class="style2">Марка автомобиля: </span>&nbsp;<asp:DropDownList 
            ID="DropDownList1" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem>Марка</asp:ListItem>
            <asp:ListItem>Audi</asp:ListItem>
            <asp:ListItem>BMW</asp:ListItem>
            <asp:ListItem>Mercedes</asp:ListItem>
        </asp:DropDownList>
&nbsp;*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Модель:</span>&nbsp;
        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True">
            <asp:ListItem>  ---     </asp:ListItem>
        </asp:DropDownList>
    &nbsp;*</p>
    <p style="text-align: center">
        <span class="style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Тип 
        топлива:&nbsp; </span>&nbsp;<asp:DropDownList ID="DropDownList3" runat="server" 
            AutoPostBack="True">
            <asp:ListItem> ---     </asp:ListItem>
            <asp:ListItem>Бензин</asp:ListItem>
            <asp:ListItem>Дизель</asp:ListItem>
        </asp:DropDownList>
&nbsp;*&nbsp; <span class="style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Год выпуска:</span>&nbsp;
        <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True">
            <asp:ListItem> ---     </asp:ListItem>
            <asp:ListItem>2012</asp:ListItem>
            <asp:ListItem>2011</asp:ListItem>
            <asp:ListItem>2010</asp:ListItem>
            <asp:ListItem>2009</asp:ListItem>
            <asp:ListItem>2008</asp:ListItem>
            <asp:ListItem>2007</asp:ListItem>
            <asp:ListItem>2006</asp:ListItem>
            <asp:ListItem>2005</asp:ListItem>
        </asp:DropDownList>
    &nbsp;*</p>
    <p style="text-align: center">
        <asp:TextBox ID="TextBox1" runat="server" Font-Size="Medium" Height="203px" 
            TextMode="MultiLine" Width="780px"></asp:TextBox>
    </p>
    <p style="text-align: center">
        <asp:Button ID="Button1" runat="server" Font-Size="Medium" Text="Смотреть" 
            onclick="Button1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Font-Size="Medium" Text="Очистить" 
            onclick="Button2_Click" />
    </p>
    </form>
</body>
</html>
