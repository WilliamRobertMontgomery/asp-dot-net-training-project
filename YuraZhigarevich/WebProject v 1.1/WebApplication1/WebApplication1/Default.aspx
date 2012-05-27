<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 81px;
        }
        .style2
        {
            width: 183px;
        }
        .style3
        {
            width: 259px;
        }
        .style4
        {
            width: 304px;
        }
        .style5
        {
            width: 254px;
        }
        .style6
        {
            width: 232px;
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
        #form1
        {
            text-align: center;
        }
        .style10
        {
            text-align: center;
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
                
            </td>
            <td class="style5">
                
            </td>
            <td class="style6">
               
            </td>
            <td class="style4">
               
            </td>
            <td class="style2">
                &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
    </table>
    
    <table style="width:100%;">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Login ID="Login1" runat="server" onauthenticate="Login1_Authenticate" 
                        style="margin-left: 250px">
                    </asp:Login>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            
        </table>
       
    <div class="style10">
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Зарегистрироваться" />
    </div>
       
    <p style="text-align: center">
        &nbsp;</p>
       
    </form>
    </body>
</html>
