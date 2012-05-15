<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<My.Lab4.Models.TimeTable>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>

                <%: Html.HiddenFor(model => model.id) %>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.DateTime) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.DateTime, Model.DateTime) %>
                <%: Html.ValidationMessageFor(model => model.DateTime) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Subj_Teach.Subject) %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownList("id_subject", (IEnumerable<SelectListItem>)ViewData["subject"])%>
                <%: Html.ValidationMessageFor(model => model.Subj_Teach.Subject.id) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Subj_Teach.Teacher) %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownList("id_teacher", (IEnumerable<SelectListItem>)ViewData["teacher"])%>
                <%: Html.ValidationMessageFor(model => model.Subj_Teach.Teacher.id) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Group) %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownList("id_group", (IEnumerable<SelectListItem>)ViewData["groups"]) %>
                <%: Html.ValidationMessageFor(model => model.id_group) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

