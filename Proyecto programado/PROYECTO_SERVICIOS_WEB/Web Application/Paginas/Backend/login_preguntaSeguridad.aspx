<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/SesionAnonimo.Master" AutoEventWireup="true" CodeBehind="login_preguntaSeguridad.aspx.cs" Inherits="Web_Application.Paginas.Backend.login_preguntaSeguridad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <link rel="stylesheet" href="../../Public/estilos/tarjetas.css">
<div style="background-image: url('../../Public/imagenes/fondo_general.png'); height: 1100px;" class="text-white">
    <div class="container">

        <div class="titulo">
            Comprobación de pregunta de seguridad
        </div>

        <div class="subtitulo">
            Por favor, ingrese su respuesta de seguridad.
        </div>

        <div class="alert alert-secondary" role="alert">
            Pista de respuesta de seguridad: 
            <br />
            <asp:Label ID="Label_pistaPreguntaSeguridad" runat="server" Text="PISTA PREGUNTA DE SEGURIDAD AQUÍ"></asp:Label>
        </div>

        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-4">
                <div class="form-group">
                    Respuesta de seguridad:
                    <asp:TextBox class="form-control" TextMode="Password" ID="TextBox_respuestaSeguridad" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button class="btn btn-primary justify-content-center" ID="Button_aceptar" runat="server" Text="Aceptar" OnClick="Button_aceptar_Click" />
                    <asp:Button class="btn btn-primary justify-content-center" ID="Button_cancelar" runat="server" Text="Cancelar" OnClick="Button_cancelar_Click" />
                </div>
            </div>
        </div>
        <br />
        <asp:Label class="alert alert-danger" ID="Label_status_error" runat="server" Text=""></asp:Label>
    </div>
</div>

</asp:Content>
