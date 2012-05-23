<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<WebProject.Models.MessageModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ReceivedMessages
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Received a messages</h2>
    <p>
        <%: Html.ActionLink("The messages","TheMessages") %><br />
        <%: Html.ActionLink("Create New", "Create") %>
    </p>
    <table>
        <tr>
            <th>
            </th>
            <th>
                Autor
            </th>
            <th>
                DateTime
            </th>
            <th>
                Text
            </th>
        </tr>
        <% foreach (var item in (ViewData["Messages"] as IEnumerable<WebProject.Models.MessageModel>))
           { %>
        <tr>
            <td>
                <%: Html.ActionLink("Details", "Details", new { id = item.Id })%><br />
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
