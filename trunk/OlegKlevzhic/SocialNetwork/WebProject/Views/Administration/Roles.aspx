<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Управление ролями
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Управление ролями</h2>
    <table>
        <tr>
            <td>
            </td>
            <td>
                Имя роли
            </td>
            <td>
            </td>
        </tr>
        <%foreach (string role in (IEnumerable)ViewData["Roles"])
          {%>
        <tr>
            <td>
                <%:Html.ActionLink("Delete", "DeleteRole", new { roleName = role }, new {onclick = "return confirm('Are you sure?');"} ) %>
            </td>
            <td>
                <%=role %>
            </td>
        </tr>
        <%} %>
    </table>
    <%:Html.ActionLink("Create new","CreateRole") %>|
    <%: Html.ActionLink("Back to menu","Default") %>
</asp:Content>
