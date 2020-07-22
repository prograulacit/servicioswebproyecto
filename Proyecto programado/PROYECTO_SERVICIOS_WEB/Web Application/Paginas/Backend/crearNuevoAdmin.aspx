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
    <div class="titulo">
        Crear un nuevo administrador
    </div>

    <div class="descripcion">
        Por favor, rellene los espacios correspondientes para crear un nuevo administrador
        <br />
        <asp:Label ID="Label_status_error" runat="server" class="badge badge-danger" Text=""></asp:Label>
        <asp:Label ID="Label_status_success" runat="server" class="badge badge-success" Text=""></asp:Label>
    </div>
    Nombre de usuario:
    <asp:TextBox ID="TextBox_nombreUsuario" runat="server"></asp:TextBox>
    <br />
    Contraseña:
    <asp:TextBox TextMode="Password" ID="TextBox_contrasenia" runat="server"></asp:TextBox>
    <br />
    Correo electrónico:
    <asp:TextBox ID="TextBox_correoElectronico" runat="server"></asp:TextBox>
    <br />
    Pregunta de seguridad:
    <asp:TextBox ID="TextBox_preguntaSeguridad" runat="server"></asp:TextBox>
    <br />
    Respuesta de seguridad:
    <asp:TextBox ID="TextBox_respuestaDeSeguridad" runat="server"></asp:TextBox>
    <br />
    <br />
    Permisos del sistema:
    <br />
    <br />
    Administrador maestro:
    <asp:CheckBox ID="CheckBox_adminMaestro" runat="server" />
    <br />
    <br />
    Seguridad:
    <asp:CheckBox ID="CheckBox_adminSeguridad" runat="server" />
    <br />
    <br />
    Mantenimiento:
    <asp:CheckBox ID="CheckBox_mantenimiento" runat="server" />
    <br />
    <br />
    Consultas:
    <asp:CheckBox ID="CheckBox_consultas" runat="server" />

    <br />
    <br />
    <asp:Button ID="Button_crearAdmin" runat="server" Text="Crear administador" OnClick="Button_crearAdmin_Click" />
    <asp:Button ID="Button_cancelar" runat="server" Text="Cancelar" OnClick="Button_cancelar_Click" />
</asp:Content>
