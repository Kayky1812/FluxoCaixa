<%@ Page Title="Cadastro de Usuários" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadUser.aspx.cs" Inherits="FluxoCaixa.Paginas.CadUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <p />
    <p />
    <p />
    <p />     

    <table>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="tbTitulo" runat="server" Text="Cadastro de Usuários" Font-Size="XX-Large" Font-Bold="True" ForeColor="#0033CC" />

            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td style="width: 181px">
                <asp:Label ID="lbNome" runat="server" />
            </td>
            <td>
                <asp:TextBox ID="txNome" runat="server" Width='200px'/>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 181px">
                <asp:Label ID="lbLogin" runat="server" />

            </td>
            <td>
                <asp:TextBox ID="txLogin" runat="server" Width='200px' />
            </td>
        </tr>
        <tr>
            <td style="width: 181px">
                <asp:Label ID="lbSenha" runat="server" />

            </td>
            <td>
                <asp:TextBox ID="txSenha" runat="server" Width='200px' />
            </td>
        </tr>

        <tr>
            <td style="width: 181px">
                <asp:Label ID="lbAdm" runat="server" />

            </td>
            <td>
                <asp:CheckBox ID="cbAdm" runat="server" />
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>

        <tr>
            <td style="text-align: left; width: 181px;">
                <asp:Button ID="btOk" runat="server" Text=" Salvar " OnClick="btOk_Click" />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btSair" runat="server" Text=" Sair " OnClick="btSair_Click"   />
            </td>
            <td>
                <asp:Button ID="btnDeletar" runat="server" Enabled="False" OnClick="btnDeletar_Click" Text="Deletar" />
                <asp:Button ID="btnLimpar" runat="server" OnClick="btnLimpar_Click" Text="Limpar" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div style="width: 600px; height: 150px; overflow-y: scroll;">
                    <asp:Literal runat="server" ID="tabela" />
                </div>
            </td>
        </tr>

    </table>

    <hr />

     <asp:Label ID="mensagem" runat="server" /> 




</asp:Content>
