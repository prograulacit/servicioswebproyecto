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
    <div class="p-3 mb-2 bg-dark text-white text-center text-uppercase font-weight-bold">
        Cambiar contraseña
    </div>

    <div class="container">
        <div class="subtitulo">
            Por favor, rellene el siguiente formulario para cambiar su contraseña.
        </div>
        <asp:Label class="badge badge-danger" ID="Label_status_error" runat="server" Text=""></asp:Label>
        <asp:Label class="badge badge-success" ID="Label_status_success" runat="server" Text=""></asp:Label>
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-6">
                <label class="text-font-normal">Contraseña actual:</label>
                <br />
                <asp:TextBox class="form-control" TextMode="Password" ID="TextBox_contraseniaActual" runat="server"></asp:TextBox>
                <br />
                <label class="text-font-normal">Contraseña nueva:</label>
                <br />
                <asp:TextBox class="form-control" TextMode="Password" ID="TextBox_contraseniaNueva" runat="server"></asp:TextBox>
                <br />
                <label class="text-font-normal">Confirmar nueva contraseña:</label>
                <br />
                <asp:TextBox class="form-control" TextMode="Password" ID="TextBox_confirmarContrasenia" runat="server"></asp:TextBox>
                <br />
                <asp:Button class="btn btn-primary" ID="Button_confirmar" runat="server" Text="Confirmar" OnClick="Button_confirmar_Click" />
                <asp:Button class="btn btn-primary" ID="Button_cancelar" runat="server" Text="Cancelar" OnClick="Button_cancelar_Click" />
            </div>
        </div>
    </div>


</asp:Content>
