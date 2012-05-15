<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<My.Lab4.Models.TimeTable>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="message"><%= ViewData["message"] %></div>
    <% using (Html.BeginForm())
       {%>
            <div class="editor-label">
                <%: Html.Label("Teacher") %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownList("idTeacher", (IEnumerable<SelectListItem>)ViewData["Teachers"])%>
            </div>
            <div class="editor-label">      
                <%: Html.Label("Group") %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownList("idGroup", (IEnumerable<SelectListItem>)ViewData["Groups"]) %>
            </div>
            <div class="editor-label">      
                <%: Html.Label("DateTime") %>
            </div>
            <div class="editor-field">
                <%: Html.TextBox("dateTime") %>
            </div>
            <input type="submit" value="Search" /> <%: Html.ActionLink("All Timetable", "List") %>
    <%} %>
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
        <% if(Model!=null) %>
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

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

