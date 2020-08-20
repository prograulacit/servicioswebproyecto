<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Backend.Master" AutoEventWireup="true" CodeBehind="crearNuevoAdmin.aspx.cs" Inherits="Web_Application.Paginas.Backend.crearNuevoAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="./index.aspx">Inicio</a></li>
            <li class="breadcrumb-item active" aria-current="page">Crear nuevo administrador</li>
        </ol>
    </nav>
        <link rel="stylesheet" href="../../Public/estilos/tarjetas.css">
<div style="background-image: url('../../Public/imagenes/fondo_general.png'); height: 1100px;">
    <div class="tp-3 mb-2 bg-dark text-white text-center text-uppercase font-weight-bold">
        Crear un nuevo administrador
    </div>
    <div class="container">
        <div class="descripcion">
            <div class="subtitulo">
                Por favor, rellene los espacios correspondientes para crear un nuevo administrador
            </div>
            <br />
            <asp:Label ID="Label_status_error" runat="server" class="badge badge-danger" Text=""></asp:Label>
            <asp:Label ID="Label_status_success" runat="server" class="badge badge-success" Text=""></asp:Label>
        </div>
        <div class="row shadow-lg p-3 mb-5 bg-white rounded">
            <div class="col-12 col-sm-12 col-md-12 col-lg-4">
                <label class="text-font-normal">Nombre de usuario:</label>
                <asp:TextBox class="form-control" ID="TextBox_nombreUsuario" runat="server"></asp:TextBox>
                <br />
                <label class="text-font-normal">Contraseña:</label>
                <asp:TextBox class="form-control" TextMode="Password" ID="TextBox_contrasenia" runat="server"></asp:TextBox>
                <br />
                <label class="text-font-normal">Correo electrónico:</label>
                <asp:TextBox class="form-control" ID="TextBox_correoElectronico" runat="server"></asp:TextBox>
                <br />
                <label class="text-font-normal">Pregunta de seguridad:</label>
                <asp:TextBox class="form-control" ID="TextBox_preguntaSeguridad" runat="server"></asp:TextBox>
                <br />
                <label class="text-font-normal">Respuesta de seguridad:</label>
                <asp:TextBox class="form-control" ID="TextBox_respuestaDeSeguridad" runat="server"></asp:TextBox>
            </div>
            <div class="col-12 col-sm-12 col-md-12 col-lg-6">
                <div class="subtitulo">
                    Permisos del sistema
                </div>
                <div class="form-group form-check">
                    <asp:CheckBox class="form-check-input" ID="CheckBox_adminMaestro" runat="server" />
                    <label class="form-check-label">Administrador maestro</label>
                </div>
                <div class="form-group form-check">
                    <asp:CheckBox class="form-check-input" ID="CheckBox_adminSeguridad" runat="server" />
                    <label class="form-check-label">Seguridad</label>
                </div>
                <div class="form-group form-check">
                    <asp:CheckBox class="form-check-input" ID="CheckBox_mantenimiento" runat="server" />
                    <label class="form-check-label">Mantenimiento:</label>
                </div>
                <div class="form-group form-check">
                    <asp:CheckBox class="form-check-input" ID="CheckBox_consultas" runat="server" />
                    <label class="text-font-label">Consultas</label>
                </div>
                <asp:Button class="btn btn-primary justify-content-center" ID="Button_crearAdmin" runat="server" Text="Crear administador" OnClick="Button_crearAdmin_Click" />
                <asp:Button class="btn btn-primary justify-content-center" ID="Button_cancelar" runat="server" Text="Cancelar" OnClick="Button_cancelar_Click" />
            </div>
        </div>
    </div>
</div>
</asp:Content>
