<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Frontend.Master" AutoEventWireup="true" CodeBehind="misArticulos.aspx.cs" Inherits="Web_Application.Paginas.Frontend.misArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="/Paginas/Frontend/Index.aspx">Inicio</a></li>
            <li class="breadcrumb-item active" aria-current="page">Mis articulos</li>
        </ol>
    </nav>
        <link rel="stylesheet" href="../../Public/estilos/tarjetas.css">
<div style="background-image: url('../../Public/imagenes/fondo_general.png'); height: 1100px;" class="text-white">
    <div class="container">

        <div class="titulo">
            Productos comprados
        </div>

        <div id="botones_navegacion">
            <ul class="nav nav-pills">
                <li class="nav-item">
                    <a id="boton_peliculas" class="nav-link active" href="#">Películas</a>
                </li>
                <li class="nav-item">
                    <a id="boton_musica" class="nav-link" href="#">Música</a>
                </li>
                <li class="nav-item">
                    <a id="boton_libros" class="nav-link" href="#">Libros</a>
                </li>
            </ul>
        </div>

        <div id="contenido">
            <div class="spinner-border text-primary" role="status">
                <span class="sr-only">Loading...</span>
            </div>
            Cargando contenido. Por favor, espere...
        </div>
    </div>
</div>
    <script src="../../Public/scripts/misArticulos.js"></script>
    <script>
        generarTabla_Peliculas();
    </script>
</asp:Content>
