<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="WebApplication1.main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            font-family: cursive;
            font-size: x-large;
            font-weight: bold;
        }
    </style>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <p>
        &nbsp;</p>
    <p class="style1">
        С помощь нашего сайта слова превращаются в покупки!</p>
    <p>
        <asp:Image ID="Image1" runat="server" Height="190px" 
            ImageUrl="~/Pictures/doska.jpg" Width="226px" />
    </p>
</form>
</body>
</html>
