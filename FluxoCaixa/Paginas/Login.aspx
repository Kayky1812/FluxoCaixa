<%@ Page Title="Login CAIXA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FluxoCaixa.Paginas.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <p/>
     <p/>
     <p/>
     <p/>
     <p/>
    <hr />
    <table>
        <tr>
            <td colspan="2" style="text-align:center">
                <asp:Label ID="lbDigiteSuaSenha" runat="server" Text="Digite sua Senha" Font-Size="XX-Large" /> 
            </td>
        </tr>
        <tr>            
            <td>
                <asp:Label ID="lbNome" runat="server" Text="Nome" Width="100px"/> 
            </td>
            <td>
                <asp:TextBox ID="nome" runat="server" Width="150px" /> 
            </td>            
        </tr>
        <tr>
            <td>
                 <asp:Label ID="lbSenha" runat="server" Text="Senha"/> 
            </td>
            <td>
                <asp:TextBox ID="senha" runat="server"  Width="150px" TextMode="Password" /> 
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btOk" runat="server" Text="OK"  Width="250px" OnClick="btOk_Click"/>
            </td>             
        </tr>
    </table>
    <hr />
     <asp:Label ID="mensagem" runat="server" /> 
    <hr />
</asp:Content>
