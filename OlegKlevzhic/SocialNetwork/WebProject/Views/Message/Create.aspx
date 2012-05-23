<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebProject.Models.CreateMessageModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    CreateMessage
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        CreateMessage</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Fields</legend>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Friend) %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownListFor(model => model.Friend, ViewData["Friends"] as IEnumerable<SelectListItem>)%>
            <%: Html.ValidationMessageFor(model => model.Friend) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Text) %>
        </div>
        <div class="editor-field">
            <%: Html.TextAreaFor(model => model.Text) %>
            <%: Html.ValidationMessageFor(model => model.Text) %>
        </div>
        <p>
            <input type="submit" value="Send" />
        </p>
    </fieldset>
    <% } %>
</asp:Content>
