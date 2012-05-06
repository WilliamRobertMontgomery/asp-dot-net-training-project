<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<My.LabWork.Policlinic.Library.Business.Doctor>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Choose
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Choose</h2>
    <table>
        <tr>
            <th>
            </th>
            <th>
                Doctor
            </th>
            <th>
                Soon reception
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: Html.ActionLink("Sign up","WriteToReception",new {id = item.Id}) %>
            </td>
            <td>
                <%: item.ToString() %>
            </td>
            <td>
                <%: ViewData.FirstOrDefault(x => x.Key == item.Id.ToString()).Value %>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
</asp:Content>
