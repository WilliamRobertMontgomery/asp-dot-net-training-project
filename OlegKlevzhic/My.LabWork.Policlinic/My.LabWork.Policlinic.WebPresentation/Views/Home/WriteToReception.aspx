<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<My.LabWork.Policlinic.Library.Business.Record>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    WriterToReception
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        WriterToReception</h2>
    <fieldset>
        <legend>Fields</legend>
        <div class="display-label">
            <%:ViewData["Record"] %></div>
    </fieldset>
    <p>
        |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
</asp:Content>
