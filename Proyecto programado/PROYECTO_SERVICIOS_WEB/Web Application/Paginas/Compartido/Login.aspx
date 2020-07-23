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
        <asp:TextBox TextMode="Password" ID="textbox_contrasenia" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="button_submit_login" runat="server" Text="Submit" OnClick="button_submit_login_Click" />
        <br />
        <asp:Label class="badge badge-danger" ID="Label_status_error" runat="server" Text=""></asp:Label>
    </div>
    <script>
        document.getElementById("ContentPlaceHolder1_textbox_nombre_usuario").autofocus;

    </script>

</asp:Content>
