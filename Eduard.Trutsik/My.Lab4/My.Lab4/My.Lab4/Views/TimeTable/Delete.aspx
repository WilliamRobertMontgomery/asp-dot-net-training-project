<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<My.Lab4.Models.TimeTable>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>

    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Fields</legend>
        
         <div class="display-label">DateTime</div>
        <div class="display-field"><%: Model.DateTime %></div>
        
        <div class="display-label">Subject</div>
        <div class="display-field"><%: Model.Subj_Teach.Subject.name %></div>

        <div class="display-label">Teacher</div>
        <div class="display-field"><%: Model.Subj_Teach.Teacher.name %></div>
        
        <div class="display-label">Group</div>
        <div class="display-field"><%: Model.Group.name %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Delete" /> |
		    <%: Html.ActionLink("Back to List", "Index") %>
        </p>
    <% } %>

</asp:Content>

