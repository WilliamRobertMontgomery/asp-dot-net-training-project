<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebProject.DataAccess.Entities.Profile>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>
            <%:ViewData["Name"] %></legend>
        <table>
            <tr>
                <td>
                    FirstName
                </td>
                <td>
                    <%: Model.FirstName %>
                </td>
            </tr>
            <tr>
                <td>
                    LastName
                </td>
                <td>
                    <%: Model.LastName %>
                </td>
            </tr>
            <tr>
                <td>
                    Gender
                </td>
                <td>
                    <%: Model.Gender %>
                </td>
            </tr>
            <tr>
                <td>
                    BirthDate
                </td>
                <td>
                    <%: String.Format("{0:dd:MM:yyy}", Model.BirthDate) %>
                </td>
            </tr>
            <tr>
                <td>
                    Country
                </td>
                <td>
                    <%: Model.Country %>
                </td>
            </tr>
            <tr>
                <td>
                    City
                </td>
                <td>
                    <%: Model.City %>
                </td>
            </tr>
            <tr>
                <td>
                    Website
                </td>
                <td>
                    <%: Model.Website %>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
