<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebProject.DataAccess.Entities.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	DetailsUser
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>DetailsUser</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">UserName</div>
        <div class="display-field"><%: Model.UserName %></div>
        
        <div class="display-label">Email</div>
        <div class="display-field"><%: Model.Email %></div>
        
        <div class="display-label">Password</div>
        <div class="display-field"><%: Model.Password %></div>
        
        <div class="display-label">IsActivated</div>
        <div class="display-field"><%: Model.IsActivated %></div>
        
        <div class="display-label">LastActivityDate</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.LastActivityDate) %></div>
        
        <div class="display-label">CreationDate</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.CreationDate) %></div>
        
        <div class="display-label">IsOnLine</div>
        <div class="display-field"><%: Model.IsOnLine %></div>
        
        <div class="display-label">IsLockedOut</div>
        <div class="display-field"><%: Model.IsLockedOut %></div>
        
        <div class="display-label">Id</div>
        <div class="display-field"><%: Model.Id %></div>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Back to List", "Users") %>
    </p>

</asp:Content>

