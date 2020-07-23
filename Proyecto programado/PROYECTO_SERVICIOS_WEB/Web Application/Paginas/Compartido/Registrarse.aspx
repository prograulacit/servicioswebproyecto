<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/SesionAnonimo.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="Web_Application.Paginas.Compartido.Registrarse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="titulo">
        Registro de nuevos usuarios
    </div>
    <div class="descripcion">
        Formulario de registro.
    </div>
    <div class="descripcion">
        <asp:Label ID="Label_error" class="badge badge-danger" runat="server" Text=""></asp:Label>
        <asp:Label ID="Label4_success" class="badge badge-success" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label runat="server" Text="Su nombre"></asp:Label>
        <br />
       <asp:TextBox ID="textbox_nombre" runat="server"></asp:TextBox>
        <br />
        <asp:Label runat="server" Text="Apellido paterno"></asp:Label>
        <br />
       <asp:TextBox ID="textbox_ap_paterno" runat="server"></asp:TextBox>
        <br />
        <asp:Label runat="server" Text="Apellido materno"></asp:Label>
        <br />
       <asp:TextBox ID="textbox_ap_materno" runat="server"></asp:TextBox>
        <br />
        <asp:Label runat="server" Text="Correo electrónico" ID="Label1"></asp:Label>
        <br />
       <asp:TextBox ID="textbox_correo_electronico" runat="server"></asp:TextBox>
        <br />
        <asp:Label runat="server" Text="Nombre de usuario" ID="Label2"></asp:Label>
        <br />
       <asp:TextBox ID="textbox_nombre_de_usuario" runat="server"></asp:TextBox>
        <br />
        <asp:Label runat="server" Text="Contraseña"></asp:Label>
        <br />
        <asp:TextBox TextMode="Password" ID="textbox_contrasenia" runat="server"></asp:TextBox>
        <br />
        <asp:Label runat="server" Text="Confirmar contraseña"></asp:Label>
        <br />
        <asp:TextBox TextMode="Password" ID="textbox_confirmar_contrasenia" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="button_submit_login" runat="server" Text="Submit" OnClick="button_submit_login_Click" />
        <a href="index.aspx">Volver</a>
    </div>
</asp:Content>
