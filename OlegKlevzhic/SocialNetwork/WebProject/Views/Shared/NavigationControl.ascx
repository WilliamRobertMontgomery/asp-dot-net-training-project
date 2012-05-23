<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated)
    {
%>
<% Html.ActionLink("Моя страница", "Users");%>
<ul>
    <li>
        <ul>
            <li>
                <%:Html.ActionLink("My page", "Default", "User")%></li>
            <li>
                <%: Html.ActionLink("Friends","Default","Friend") %></li>
            <li>
                <%: Html.ActionLink("Messages","ReceivedMessages","Message") %></li>
            <li>
                <%: Html.ActionLink("Edit my profile", "Edit","User") %></li>
            <li>
                <%: Html.ActionLink("Search","Default","Search") %></li>
            <%if (Roles.IsUserInRole("Administrator"))
              { %>
            <li>
                <%: Html.ActionLink("Administration panel", "Default", "Administration")%></li>
            <%} %>
        </ul>
    </li>
</ul>
<%
    }
%>
