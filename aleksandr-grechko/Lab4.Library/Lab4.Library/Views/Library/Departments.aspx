<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Lab4.Library.Models.LibraryDepartment>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Отделы
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Отделы</h2>


    <% foreach (var item in Model) { %>
        
        <p>
            <%: Html.ActionLink(item.Name, "Department", new { id=item.Id.ToString() }) %>
        </p>    
    <% } %>


</asp:Content>

