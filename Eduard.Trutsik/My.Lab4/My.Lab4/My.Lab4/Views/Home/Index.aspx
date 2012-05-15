<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<My.Lab4.Models.TimeTable>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Timetable Now
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: ViewData["Message"] %></h2>

    <table>
        <tr>
            <th></th>
            <th>
                DateTime
            </th>
            <th>
                Subject
            </th>
            <th>
                Teacher
            </th>
            <th>
                Group
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.id }) %> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.id })%>
            </td>
            <td>
                <%:item.DateTime %>
            </td>
            <td>
                <%: item.Subj_Teach.Subject.name %>
            </td>
            <td>
                <%: item.Subj_Teach.Teacher.name %>
            </td>
            <td>
                <%: item.Group.name %>
            </td>
        </tr>
    
    <% } %>

    </table>

</asp:Content>

