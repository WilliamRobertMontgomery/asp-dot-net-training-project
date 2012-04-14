<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Бесплатные объявления</title>
    <style type="text/css">
        .style1
        {
            font-family: "Monotype Corsiva";
            font-size: 34pt;
            color: #000099;
        }
        .style2
        {
            text-align: center;
            font-size: large;
        }
        .style3
        {
            font-size: large;
        }
    </style>
</head>
<body background="Pictures/watbkgnd.gif">
    <form id="form1" runat="server">
    <div class="style1" style="text-align: center">
    
        Газета бесплатных объявлений</div>
    <p>
        &nbsp;</p>
    <table width="100%">
        <tr>
            <td class="style2">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            <td class="style3" style="text-align: center">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/main.aspx" 
                    Target="a" Font-Size="X-Large">Главная</asp:HyperLink>
            </td>
            <td class="style2">
                <asp:HyperLink ID="HyperLink2" runat="server" 
                    NavigateUrl="~/FindDeclaration.aspx" Target="a" Font-Size="X-Large">Смотреть 
                объявления</asp:HyperLink>
            </td>
            <td class="style2">
                <asp:HyperLink ID="HyperLink3" runat="server" 
                    NavigateUrl="~/AddDeclaration.aspx" Target="a" Font-Size="X-Large">Подать объявление</asp:HyperLink>
            </td>
            <td class="style2">
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/about.aspx" 
                    Target="a" Font-Size="X-Large">О нас</asp:HyperLink>
            </td>
            <td class="style2">
                &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
    </table>
    </form>
    <table style="width: 100%; height: 550px">
        <tr>
            <td>
                <iframe id="I1" frameborder="0" name="a" scrolling="no" 
                    style="width: 100%; height: 436px;" src="main.aspx"></iframe>
            </td>
        </tr>
    </table>
</body>
</html>
