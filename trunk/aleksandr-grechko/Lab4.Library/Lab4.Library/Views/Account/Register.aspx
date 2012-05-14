<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Lab4.Library.Models.RegisterModel>" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Регистрация
</asp:Content>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Регистрация нового читателя</h2>

    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true, "Исправьте ошибки и попробуйте снова.") %>
        <div>
            <fieldset>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.UserName) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.UserName) %>
                    <%: Html.ValidationMessageFor(m => m.UserName) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Address) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.Address) %>
                    <%: Html.ValidationMessageFor(m => m.Address) %>
                </div>
                
                <p>
                    <input type="submit" value="Регистрация" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
