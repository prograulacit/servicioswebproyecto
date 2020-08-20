<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Frontend.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Web_Application.Paginas.Frontend.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item active" aria-current="page">Inicio</li>
        </ol>
    </nav>
        <link rel="stylesheet" href="../../Public/estilos/tarjetas.css">
<div style="background-image: url('../../Public/imagenes/fondo_general.png'); height: 1100px;" class="text-white">
    <div class="container">
        <br />
        <br />
        <br />
        <div class="justify-content-center ">
            <h1 class="text-uppercase text-muted text-white">Bienvenido E-Descargas</h1>
        </div>
        <div class="subtitulo text-muted">
            E-Descargas online es una plataforma de compra y descargas de péliculas, libros y música.
        </div>
        <div class="text-muted">
            Para ver el catalogo de productos. Dirijase a cualquiera de nuestras categorias de productos.
            <ul>
                <li><a href="Peliculas.aspx">Péliculas</a>: péliculas en formato .mp4 .</li>
            </ul>
            <ul>
                <li><a href="Libros.aspx">Libros</a>: libros en formato PDF.</li>
            </ul>
            <ul>
                <li><a href="Musica.aspx">Música</a>: música en formato .mp3</li>
            </ul>
        </div>

        <ul>
            <li class="text-muted">
                Este es un proyecto progrado para el curso Servicios Web - ULACIT 2020.
            </li>
        </ul>
    </div>
</div>
</asp:Content>
