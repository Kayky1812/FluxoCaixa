<%@ Page Title="Menu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="menu.aspx.cs" Inherits="FluxoCaixa.Paginas.menu" %>
  
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td colspan="2" style="text-align:center;font-size:x-large">
                <asp:Label ID="lbMenu" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <a href="formCaixa.aspx">Caixa</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td>
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <a href="CadUser.aspx">Cadastro usuários</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
 