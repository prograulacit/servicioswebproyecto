<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Frontend.Master" AutoEventWireup="true" CodeBehind="ajustesUsuario.aspx.cs" Inherits="Web_Application.Paginas.Frontend.ajustesUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="titulo">
        <asp:Label ID="Label_titulo" runat="server" Text="Ajustes del usuario XXXXXXXXXX"></asp:Label>
    </div>
    <br />
    <div class="container">
        <div class="row">
            <div class="col-12 col-sm-5 col-md-4 col-lg-4">
                <div class="sub_titulo">
                    Parametros generales
                </div>
                <div class="label">
                    Nombre
                </div>
                <div class="input">
                    <asp:TextBox ID="TextBox_nombre" runat="server"></asp:TextBox>
                </div>
                <div class="label">
                    Primer apellido
                </div>
                <div class="input">
                    <asp:TextBox ID="TextBox_primer_apellido" runat="server"></asp:TextBox>
                </div>
                <div class="label">
                    Segundo apellido
                </div>
                <div class="input">
                    <asp:TextBox ID="TextBox_segundo_apellido" runat="server"></asp:TextBox>
                </div>
                <div class="label">
                    Correo electrónico
                </div>
                <div class="input">
                    <asp:TextBox ID="TextBox_correo_electronico" runat="server"></asp:TextBox>
                </div>
                <div class="label">
                    Nombre de usuario
                </div>
                <div class="input">
                    <asp:TextBox ID="TextBox_nombreUsuario" runat="server"></asp:TextBox>
                </div>
                <asp:Label ID="Label_status_success_parametros" runat="server" Text=""></asp:Label>
                <asp:Label ID="Label_status_failed_parametros" runat="server" Text=""></asp:Label>
                <br />
                <asp:Button ID="Button_actualizarDatos" runat="server" Text="Actualizar datos" OnClick="Button_actualizarDatos_Click" />
            </div>
            <div class="col-12 col-sm-4 col-md-4 col-lg-4">
                <div class="sub_titulo">
                    Cambiar contraseña
                </div>
                <div class="label">
                    Contraseña actual
                </div>
                <div class="input">
                    <asp:TextBox ID="TextBox_contraseniaActual" runat="server"></asp:TextBox>
                </div>
                <div class="label">
                    Contraseña nueva
                </div>
                <div class="input">
                    <asp:TextBox ID="TextBox_contraseniaNueva" runat="server"></asp:TextBox>
                </div>
                <div class="label">
                    Confirmar contraseña
                </div>
                <div class="input">
                    <asp:TextBox ID="TextBox_contraseniaConfirmar" runat="server"></asp:TextBox>
                </div>
                <asp:Label ID="Label1_status_success_contrasenia" runat="server" Text=""></asp:Label>
                <asp:Label ID="Label1_status_failed_contrasenia" runat="server" Text=""></asp:Label>
                <br />
                <asp:Button ID="Button_actualizarContrasenia" runat="server" Text="Actualizar contraseña" OnClick="Button_actualizarContrasenia_Click" />
            </div>
        </div>
        <br />
        <br />
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-12">
                <div class="eliminar_cuenta">
                    <asp:LinkButton ID="LinkButton_borrarCuenta" runat="server" OnClick="LinkButton_borrarCuenta_Click">Eliminar mi cuenta E-Descargas</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

    <style>
        .sub_titulo {
            font-size: 24px;
            padding-bottom: 22px;
            color: #999999;
        }

        .eliminar_cuenta {
            padding: 5px;
            background: #ffc4c4;
            display: inline;
            border-radius: 25px;
            border: 2px solid  #ffc4c4;
        }
    </style>

</asp:Content>
