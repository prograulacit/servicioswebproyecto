<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/SesionAnonimo.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Web_Application.Paginas.Compartido.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="titulo">
        Bienvenido/a a E-Descargas
    </div>
    <div class="descripcion">
        <br />
        <a href="Login.aspx">Login</a>
        <br />
        <a href="Registrarse.aspx">Crear nueva cuenta</a>
    </div>
</asp:Content>
