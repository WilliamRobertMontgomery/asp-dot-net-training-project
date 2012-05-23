<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="WebApplication1.Interface.News" %>

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
        .style3
        {
            text-align: justify;
        }
        .style4
        {
            width: 148px;
            text-align: justify;
        }
        .style5
        {
            font-size: large;
            font-family: "Times New Roman", Times, serif;
        }
        .style6
        {
            font-size: medium;
        }
        .style7
        {
            font-size: medium;
            font-weight: bold;
        }
        .style8
        {
            text-align: justify;
            font-size: medium;
        }
        .style9
        {
            font-weight: bold;
        }
        .style10
        {
            font-family: "Times New Roman", Times, serif;
        }
        .style11
        {
            font-weight: bold;
            font-family: "Times New Roman", Times, serif;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center" class="style1">
    
        Автоновости<br />
        <table style="width:100%;">
            <tr class="style5">
                <td class="style4">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Pictures/02.jpg" />
                </td>
                <td class="style3">
                    <b>2</b><span class="style7">3.05.2012 Mercedes-Benz AMG привез в Канны лимузины 
                    золотого цвета Mercedes-Benz.</span> <span class="style6">AMG предоставил для 
                    Каннского кинофестиваля золотые лимузины и SUV.</span></td>
            </tr>
            <tr class="style5">
                <td class="style4">
                    <asp:Image ID="Image2" runat="server" Height="71px" 
                        ImageUrl="~/Pictures/03.jpg" Width="118px" />
                </td>
                <td class="style8">
        <span class="style7">22.05.2012 Tesla поможет Mercedes-Benz с разработкой 
        электромобиля A-класса.</span><span class="style6"> Североамериканская компания Tesla, 
        специализирующаяся на выпуске автомобилей с электрическими силовыми установками, 
        подписала контракт с концерном Daimler.</span></td>
            </tr>
            <tr class="style5">
                <td class="style4">
                    <asp:Image ID="Image4" runat="server" Height="67px" 
                        ImageUrl="~/Pictures/05.jpg" Width="115px" />
                </td>
                <td class="style8">
        <span class="style9">22.05.2012 BMW - самый ценный бренд.</span> Немецкий 
        производитель BMW сместил «Тойоту» с первого места в ежегодном рейтинге самых 
        ценных автомобильных брендов, подготовленном британской исследовательской 
        компанией Millward Brown.</td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Image ID="Image5" runat="server" Height="64px" 
                        ImageUrl="~/Pictures/06.jpg" Width="113px" />
                </td>
                <td class="style8">
        <span class="style11">21.05.2012 Стив Джобс хотел спроектировать автомобиль iCar.</span><span 
                        class="style10"> 
        Один из основателей и бывший главный управляющий корпорации Apple Стив Джобс 
        хотел спроектировать автомобиль под названием iCar. Об этом сообщил член совета 
        директоров компании Мики Дрекслер.</span></td>
            </tr>
            <tr class="style5">
                <td class="style4">
                    <asp:Image ID="Image6" runat="server" Height="75px" 
                        ImageUrl="~/Pictures/07.jpg" Width="114px" />
                </td>
                <td class="style8">
        <span class="style9">21.05.2012 У BMW появится передний привод.</span> Через два 
        года баварцы представят BMW 1GT, который не разделит платформу с заднеприводной 
        &quot;копейкой&quot;. Это значит, что будущая новинка будет переднеприводной.</td>
            </tr>

        </table>
    </div>
    </form>
    </body>
</html>
