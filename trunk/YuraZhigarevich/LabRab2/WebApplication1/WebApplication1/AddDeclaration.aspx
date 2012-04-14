<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDeclaration.aspx.cs" Inherits="WebApplication1.AddDeclaration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            font-family: cursive;
            font-size: x-large;
        }
    </style>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div class="style1">
    
        Подать объявление</div>
    <p>
        Введите текст объявления:</p>
    <asp:TextBox ID="TextBox1" runat="server" Font-Size="X-Large" Width="420px"></asp:TextBox>
    <p>
        &nbsp;</p>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        Text="Сохранить" Font-Size="Medium" />
    <asp:Button ID="Button2" runat="server" Font-Size="Medium" 
        onclick="Button2_Click" style="margin-left: 85px" Text="Очистить" />
    <p>
        &nbsp;</p>
&nbsp;&nbsp;&nbsp;&nbsp;
    </form>
</body>
</html>
