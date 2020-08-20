<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/SesionAnonimo.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Web_Application.Paginas.Compartido.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="background-image: url('../../Public/imagenes/fondo_general.png'); height: 726px;">
    <div class="p-3 mb-2 bg-dark text-white text-center text-uppercase font-weight-bold">
        Bienvenido/a a E-Descargas
    </div>
    <div class="container">
        <div class="row justify-content-center">
            <div class="form-group col-4">
                <br/>
                <a class="h2" href="Login.aspx">Login</a>
                <br />
                <br/>
                <br />
                <br/>
                <a class="h2" href="Registrarse.aspx">Crear nueva cuenta</a>
            </div>
        </div>
    </div>
</div>
</asp:Content>
