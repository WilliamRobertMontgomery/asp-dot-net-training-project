<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<WebProject.DataAccess.Entities.User>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Users
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Users</h2>
    <table>
        <tr>
            <th>
            </th>
            <th>
                UserName
            </th>
            <th>
                Email
            </th>
            <th>
                IsOnLine
            </th>
            <th>
                IsLockedOut
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: Html.ActionLink("Details", "DetailsUser", new { id = item.Id })%>
                |
                <%: Html.ActionLink("Delete", "DeleteUser", new { id = item.Id }, new {onclick = "return confirm('Are you sure?');"})%>
                <br />
                <%: Html.ActionLink("Lock", "LockUser", new { id = item.Id })%>
                |
                <%: Html.ActionLink("Unlock", "UnlockUser", new { id = item.Id })%>
            </td>
            <td>
                <%: item.UserName %>
            </td>
            <td>
                <%: item.Email %>
            </td>
            <td>
                <%: item.IsOnLine %>
            </td>
            <td>
                <%: item.IsLockedOut %>
            </td>
        </tr>
        <% } %>
    </table>
    <%: Html.ActionLink("Back to menu","Default") %>
</asp:Content>
