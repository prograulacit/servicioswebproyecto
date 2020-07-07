<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/SesionAnonimo.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web_Application.Paginas.Compartido.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="titulo">
        Login
    </div>
    <div class="descripcion">
        Formulario de inicio de sesión.
    </div>
    <div class="descripcion">
        <asp:Label runat="server" Text="Nombre de usuario"></asp:Label>
        <br />
       <asp:TextBox ID="textbox_nombre_usuario" runat="server"></asp:TextBox>
        <br />
        <asp:Label runat="server" Text="Contraseña"></asp:Label>
        <br />
        <asp:TextBox ID="textbox_contrasenia" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="button_submit_login" runat="server" Text="Submit" OnClick="button_submit_login_Click" />
    </div>
</asp:Content>
