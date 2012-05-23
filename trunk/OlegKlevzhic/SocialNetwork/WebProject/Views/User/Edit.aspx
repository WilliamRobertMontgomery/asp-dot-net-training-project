<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebProject.DataAccess.Entities.Profile>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Edit</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Fields</legend>
        <div class="editor-label">
            <%: Html.HiddenFor(model => model.Id_User) %>
        </div>
        <div class="editor-field">
            <%: Html.HiddenFor(model => model.Id_User)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.FirstName) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.FirstName) %>
            <%: Html.ValidationMessageFor(model => model.FirstName) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.LastName) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.LastName) %>
            <%: Html.ValidationMessageFor(model => model.LastName) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Gender) %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownListFor(model => model.Gender, new List<SelectListItem>() { new SelectListItem() { Text = "Мужской" }, new SelectListItem() { Text = "Женский" } })%>
            <%: Html.ValidationMessageFor(model => model.Gender) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.BirthDate) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.BirthDate, String.Format("{0:g}", Model.BirthDate)) %>
            <%: Html.ValidationMessageFor(model => model.BirthDate) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Website) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Website) %>
            <%: Html.ValidationMessageFor(model => model.Website) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Country) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Country) %>
            <%: Html.ValidationMessageFor(model => model.Country) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.City) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.City) %>
            <%: Html.ValidationMessageFor(model => model.City) %>
        </div>
        <div class="editor-label">
            <%: Html.HiddenFor(model => model.Id)%>
        </div>
        <div class="editor-field">
            <%: Html.HiddenFor(model => model.Id)%>
        </div>
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Back to List", "Default") %>
    </div>
</asp:Content>
