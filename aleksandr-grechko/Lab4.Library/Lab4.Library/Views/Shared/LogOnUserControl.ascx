<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        Пользователь <b><%: Page.User.Identity.Name %></b>
        [ <%: Html.ActionLink("Выйти", "LogOff", "Account") %> ]
<%
    }
    else {
%> 
        [ <%: Html.ActionLink("Войти", "LogOn", "Account") %> ]
<%
    }
%>