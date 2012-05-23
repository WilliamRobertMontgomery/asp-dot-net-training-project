<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Панель администрирования
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Панель администрирования
    </h2>
    <ul>
        <li>
            <%: Html.ActionLink("Управление пользователями","Users") %></li>
        <li>
            <%: Html.ActionLink("Управление ролями","Roles") %></li>
    </ul>
</asp:Content>
