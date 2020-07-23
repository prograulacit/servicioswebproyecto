<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Frontend.Master" AutoEventWireup="true" CodeBehind="Peliculas.aspx.cs" Inherits="Web_Application.Paginas.Frontend.Peliculas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="/Paginas/Frontend/Index.aspx">Inicio</a></li>
            <li class="breadcrumb-item">Búsqueda</li>
            <li class="breadcrumb-item active" aria-current="page">Películas</li>
        </ol>
    </nav>
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <br />
                <h3 class="text-uppercase text-muted">Búsqueda de Películas</h3>
                <br />
                <label class="text-font-normal">Genero</label>
                <input type="text" id="input_peli_genero" placeholder="Genero" class="form-control sm-1" aria-label="Search" />
                <br />
                <label class="text-font-normal">Nombre</label>
                <input type="text" id="input_peli_nombre" placeholder="Nombre" class="form-control" aria-label="Search" />
                <br />
                <label class="text-font-normal">Año</label>
                <input type="text" id="input_peli_anio" placeholder="Año" class="form-control" aria-label="Search" />
                <br />
                <label class="text-font-normal">Idioma</label>
                <input type="text" id="input_peli_idioma" placeholder="Idioma" class="form-control" aria-label="Search" />
                <br />
                <label class="text-font-normal">Actores</label>
                <input type="text" id="input_peli_actores" placeholder="Actores" class="form-control" aria-label="Search" />
                <br />
                <button class="btn btn-outline-success my-2 my-sm-0" type="button" onclick="button_submit_pelicula_buscar()">Buscar</button>
            </div>
            <div class="col-md-8">
                <br />
                <br />
                <br />
                <br />
                <div id="tabla_Peliculas"></div>
            </div>
        </div>
    </div>
    <script src="../../Public/scripts/peliculas.js"></script>
</asp:Content>
