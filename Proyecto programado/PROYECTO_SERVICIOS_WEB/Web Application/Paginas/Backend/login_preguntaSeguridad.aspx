<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/SesionAnonimo.Master" AutoEventWireup="true" CodeBehind="login_preguntaSeguridad.aspx.cs" Inherits="Web_Application.Paginas.Backend.login_preguntaSeguridad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Comprobación de pregunta de seguridad para administradores.</p>
    <p>
        Por favor, ingrese su respuesta de seguridad.</p>
    <p>
        Pista de respuesta de seguridad:</p>
    <p>
        <asp:Label ID="Label_pistaPreguntaSeguridad" runat="server" Text="PISTA PREGUNTA DE SEGURIDAD AQUÍ"></asp:Label>
    </p>
    <p>
        Respuesta de seguridad:</p>
    <p>
        &nbsp;<asp:TextBox TextMode="Password" ID="TextBox_respuestaSeguridad" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button_aceptar" runat="server" Text="Aceptar" OnClick="Button_aceptar_Click" />
    </p>
    <p>
        <asp:Button ID="Button_cancelar" runat="server" Text="Cancelar" OnClick="Button_cancelar_Click" />
    </p>
    <p>
        <asp:Label class="badge badge-danger" ID="Label_status_error" runat="server" Text=""></asp:Label>
    </p>
</asp:Content>
