<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Поиск книги
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Поиск книги</h2>
    
    <% using (Html.BeginForm())
       {%>

        <div class="editor-label">
            Строка поиска:
        </div>
        <div class="editor-field">
            <%: Html.TextBox("SearchText")%>
            <%: Html.ValidationMessage("SearchText")%>
        </div>

        <fieldset>
        <div>
            <%: Html.RadioButton("SearchBy", "author", true)%> Поиск по автору
        </div>
        <div>
			<%: Html.RadioButton("SearchBy", "title", false)%> Поиск по названию
        </div>
        </fieldset>

        <p>
			<input type="submit" value="Поиск" />
        </p>

    <% } %>
</asp:Content>
