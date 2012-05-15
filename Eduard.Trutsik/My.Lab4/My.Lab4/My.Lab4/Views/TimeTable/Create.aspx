<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<My.Lab4.Models.TimeTable>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <div id="message"><%= ViewData["message"] %></div>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>

                <%: Html.HiddenFor(model => model.id) %>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.DateTime) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.DateTime) %>
                <%: Html.ValidationMessageFor(model => model.DateTime) %>
            </div>
            
            

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Subj_Teach.Teacher) %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model=>model.Subj_Teach.Teacher.id, (IEnumerable<SelectListItem>)ViewData["Teachers"])%>
                <%: Html.ValidationMessageFor(model => model.Subj_Teach.Teacher.id) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Subj_Teach.Subject) %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model=>model.Subj_Teach.Subject.id, (IEnumerable<SelectListItem>)ViewData["Subjects"])%>
                <%: Html.ValidationMessageFor(model => model.Subj_Teach.Subject.id) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Group) %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model=>model.id_group, (IEnumerable<SelectListItem>)ViewData["Groups"]) %>
                <%: Html.ValidationMessageFor(model => model.id_group) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

