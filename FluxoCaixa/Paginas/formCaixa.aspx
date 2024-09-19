<%@ Page Title="Caixa" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="formCaixa.aspx.cs" Inherits="FluxoCaixa.Paginas.formCaixa" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">        
     <p />    
    <table>
        <tr>
            <td style="width: 150px">
                <asp:Label ID="lbData" runat="server" Style="width: 200px" /></td>
            <td>
                <asp:TextBox ID="txData" runat="server" Width="100px" /></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbDescricao" runat="server" /></td>
            <td>
                <asp:TextBox ID="txDescricao" runat="server" Width="300px" /></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbValor" runat="server" /></td>
            <td>
                <asp:TextBox ID="txValor" runat="server" Width="100px" /></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:RadioButton ID="rbCredito" runat="server" GroupName="cd" />&nbsp;<asp:Label ID="lbCredito" runat="server" />&nbsp;&nbsp;&nbsp; 
                 <asp:RadioButton ID="rbDebito" runat="server" GroupName="cd" />&nbsp;<asp:Label ID="lbDebito" runat="server" /></td>
        </tr>
    </table>

    <hr />
    <table width="100%">
        <tr>
            <td>
                <asp:Button ID="btOk" runat="server" OnClick="btOk_Click" />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btSair" runat="server" OnClick="btSair_Click" />
                 &nbsp; &nbsp;<asp:Button ID="btnFechar" runat="server" Text="Fechar" OnClick="btnFechar_Click" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    
    <hr />
    <div style="width: 600px; height: 150px; overflow-y: scroll;">
        <asp:Literal runat="server" ID="tabela" />
    </div>  
    <hr />
    <asp:Label ID="lbSaldo" runat="server" />&nbsp;&nbsp;
    <asp:Label ID="lbValorSaldo" runat="server" />
    <hr />

    <table Width="600px">
    <tr>
        <td>
            <asp:Label ID="lbDataInicial" runat="server" Text="Data inicio"></asp:Label>
        </td>
        <td colspan="3">
            <asp:Label ID="lbDataFinal" runat="server" Text="Data fim"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txDatainicial" runat="server" Width="100px"></asp:TextBox>
        </td>
        <td>
            <asp:TextBox ID="txDataFinal" runat="server" Width="100px"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btCalcula" runat="server" Width="97px" Text="Calcula" OnClick="btCalcula_Click" />
        </td>
        <td>
            <asp:Label ID="lbResultado" runat="server"></asp:Label>
        </td>
    </tr>
</table>


    <asp:Label ID="mensagem" runat="server" /> 


    
</asp:Content>
