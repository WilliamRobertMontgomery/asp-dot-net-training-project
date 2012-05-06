<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<My.LabWork.Policlinic.Library.Business.Specialization>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>           
        <div class="display-label">NameSpecialization</div>
        <div class="display-field"><%: Model.NameSpecialization %></div>      
    </fieldset>
    <p>
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

