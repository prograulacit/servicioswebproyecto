<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Frontend.Master" AutoEventWireup="true" CodeBehind="eliminarCuenta.aspx.cs" Inherits="Web_Application.Paginas.Frontend.eliminarCuenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">


        <div class="titulo">
            Eliminar cuenta
        </div>

        <div class="descripcion">
            Para eliminar su cuenta, vuelva a escribir su contraseña y nombre de usuario.
        </div>

        <div class="text_nombre">
            Nombre de usuario
        </div>
        <asp:TextBox ID="TextBox_nombreUsuario" runat="server"></asp:TextBox>
        <div class="text_nombre">
            Contraseña
        </div>
        <asp:TextBox TextMode="Password" ID="TextBox_contrasenia" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label_status_error" runat="server" Text="" class="badge badge-danger"></asp:Label>
        <br />
        <asp:Button ID="Button_eliminarCuenta" runat="server" Text="Eliminar cuenta" OnClick="Button_eliminarCuenta_Click" />
    </div>
</asp:Content>
