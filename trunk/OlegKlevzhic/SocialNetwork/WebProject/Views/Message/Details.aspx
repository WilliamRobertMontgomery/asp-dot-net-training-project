<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebProject.Models.MessageModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Details</h2>
    <fieldset>
        <legend>
            <%: ViewData["TitleMessage"].ToString() %></legend>
        <div class="display-field">
            <%: Model.Text %></div>
    </fieldset>
    |
    <%: Html.ActionLink("Back to List", "ReceivedMessages") %>
</asp:Content>
