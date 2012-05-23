<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApplication1.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 81px;
            font-size: x-large;
            text-align: center;
        }
        .style2
        {
            width: 183px;
            font-size: x-large;
            text-align: center;
        }
        .style3
        {
            width: 210px;
        }
        .style4
        {
            width: 347px;
            text-align: center;
        }
        .style6
        {
            width: 425px;
            text-align: center;
        }
        .style7
        {
            text-align: center;
            width: 436px;
            font-family: "Segoe Script";
            font-weight: 700;
            color: #000099;
        }
        .style8
        {
            width: 185px;
        }
        .style9
        {
            font-size: large;
        }
        .style10
        {
            width: 465px;
            text-align: center;
        }
        .style11
        {
            font-size: x-large;
        }
        </style>
</head>
<body background="Pictures/bg.png">
    <form id="form1" runat="server">
    <div>
    <table width="100%">
    <tr>
    <td class="style8">  
        <asp:Image ID="Image2" runat="server" Height="161px" 
            ImageUrl="~/Pictures/01.jpeg" Width="315px" />
        </td>
    <td class="style7">  
        <span class="style9">Приглашаем воспользоваться интернет-сервисом 
        </span> 
        <br class="style9" />
        <span class="style9">по покупке и продаже автомобилей!</span></td>
    <td>  </td>
    </tr>
    </table>
    </div>
    <table width="100%">
        <tr>
            <td class="style1">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            <td class="style3" style="text-align: center">
                
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="style11" 
                    Font-Size="Large" NavigateUrl="~/Interface/Main.aspx" Target="a">Главная</asp:HyperLink>
                
            </td>
            <td class="style10">
                
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="style11" 
                    Font-Size="Large" NavigateUrl="~/Interface/FindDeclaration.aspx" 
                    Target="a">Смотреть объявления</asp:HyperLink>
                
            </td>
            <td class="style6">
               
                <asp:HyperLink ID="HyperLink3" runat="server" CssClass="style11" 
                    Font-Size="Large" NavigateUrl="~/Interface/AddDeclaration.aspx" Target="a">Подать объявление</asp:HyperLink>
               
            </td>
            <td class="style4">
               
                <asp:HyperLink ID="HyperLink4" runat="server" CssClass="style11" 
                    Font-Size="Large" NavigateUrl="~/Interface/News.aspx" 
                    style="text-align: center" Target="a">Новости</asp:HyperLink>
               
            </td>
            <td class="style2">
                &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
    </table>
    
    <table style="width: 100%; height: 550px">
        <tr>
            <td>
                <iframe id="I1" frameborder="0" name="a" scrolling="no" 
                    style="width: 100%; height: 436px;" src="Interface/Main.aspx"></iframe>
            </td>
        </tr>
    </table>
    </form>
    </body>
</html>
