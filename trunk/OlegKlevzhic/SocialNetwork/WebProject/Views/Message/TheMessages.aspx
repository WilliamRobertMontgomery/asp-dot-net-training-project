<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<WebProject.Models.MessageModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    TheMessages
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        The messages</h2>
    <p>
        <%: Html.ActionLink("Received a messages","ReceivedMessages") %><br />
        <%: Html.ActionLink("Create New", "Create") %>
    </p>
    <table>
        <tr>
            <th>
            </th>
            <th>
                Addressee
            </th>
            <th>
                DateTime
            </th>
            <th>
                Text
            </th>
        </tr>
        <% foreach (var item in ViewData["Messages"] as IEnumerable<WebProject.Models.MessageModel>)
           { %>
        <tr>
            <td>
                <%: Html.ActionLink("Details", "Details", new { id = item.Id })%>
                |
                <%: Html.ActionLink("Delete", "Delete", new { id = item.Id })%>
            </td>
            <td>
                <%: item.Autor %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.DateTime) %>
            </td>
            <td>
                <%: item.Text %>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
