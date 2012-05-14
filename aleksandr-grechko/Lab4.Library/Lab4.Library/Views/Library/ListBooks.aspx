<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Lab4.Library.Models.Book>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%: ViewData["Title"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: ViewData["Title"] %></h2>

    <table>
        <tr>

			<%
				if (Request.IsAuthenticated)
				{
			%>
            <th></th>
			<%
				}
			%>

            <th>
                Автор
            </th>
            <th>
                Название
            </th>
            <th>
                Год
            </th>
            <th>
                Отдел
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
			<%
				if (Request.IsAuthenticated)
				{
			%>
            <td>
                <%: Html.ActionLink("Заказать", "Order", new { id=item.Id }) %>
            </td>
			<%
				}
			%>
            <td>
                <%: item.Author %>
            </td>
            <td>
                <%: item.Title %>
            </td>
            <td>
                <%: item.Year %>
            </td>
            <td>
                <%: item.Department.Name %>
            </td>
        </tr>
    
    <% } %>

    </table>

</asp:Content>

