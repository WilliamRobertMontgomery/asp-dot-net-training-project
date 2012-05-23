<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<WebProject.DataAccess.Entities.Profile>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ListFriends
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        ListFriends</h2>
    <table>
        <tr>
            <th>
            </th>
            <th>
                FirstName
            </th>
            <th>
                LastName
            </th>
            <th>
                Gender
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: Html.ActionLink("Send a message", "CreateMessage", new { id = item.Id })%><br />
                <%: Html.ActionLink("Details", "Details", new { id = item.Id })%>
                |
                <%: Html.ActionLink("Delete", "Delete", new { id = item.Id })%>
            </td>
            <td>
                <%: item.FirstName %>
            </td>
            <td>
                <%: item.LastName %>
            </td>
            <td>
                <%: item.Gender %>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
