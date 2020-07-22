<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Backend.Master" AutoEventWireup="true" CodeBehind="cambiarContrasenia.aspx.cs" Inherits="Web_Application.Paginas.Backend.cambiarContrasenia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="./index.aspx">Inicio</a></li>
            <li class="breadcrumb-item active" aria-current="page">Cambiar contraseña</li>
        </ol>
    </nav>
    <div class="titulo">
        Cambiar contraseña
    </div>

    <div class="descripcion">
        Por favor, rellene el siguiente formulario para cambiar su contraseña.
    </div>

    <div>
        <asp:Label class="badge badge-danger" ID="Label_status_error" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label class="badge badge-success" ID="Label_status_success" runat="server" Text=""></asp:Label>
        <br />
        Contraseña actual:
        <br />
        <asp:TextBox TextMode="Password" ID="TextBox_contraseniaActual" runat="server"></asp:TextBox>
        <br />
        Contraseña nueva:
        <br />
        <asp:TextBox TextMode="Password" ID="TextBox_contraseniaNueva" runat="server"></asp:TextBox>
        <br />
        Confirmar nueva contraseña:
        <br />
        <asp:TextBox TextMode="Password" ID="TextBox_confirmarContrasenia" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button_confirmar" runat="server" Text="Confirmar" OnClick="Button_confirmar_Click" />
        <asp:Button ID="Button_cancelar" runat="server" Text="Cancelar" OnClick="Button_cancelar_Click" />
    </div>

</asp:Content>
