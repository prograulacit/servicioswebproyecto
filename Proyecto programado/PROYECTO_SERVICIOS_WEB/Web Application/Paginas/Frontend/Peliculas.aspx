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
    <div class="container" id="main_container">
        <div class="row justify-content-center">
            <div class="form-group col-4">
                <br />
                <h3 class="p-3 mb-2 bg-dark text-white text-center text-uppercase font-weight-bold">Búsqueda de Películas</h3>
                <br />
                <label class="text-font-normal">Genero</label>
                <div class="spinner-border text-primary input_peli_genero_spinner" role="status">
                    <span class="sr-only">Loading...</span>
                </div>
                <select id="input_peli_genero" class="form-control"></select>
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
                <button class="btn btn-primary justify-content-center" type="button" onclick="button_submit_pelicula_buscar()">Buscar</button>
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
    <div id="video_container" class="container" style="display:none">	
        <div class="column">	
            <a href="#" class="btn btn-secondary mb-4" onclick="ir_a_tabla()">Atras</a>	
            <div>	
                <video id="pelicula_player" width="480" height="320" controls="controls"></video>	
            </div>	
        </div>	
    </div>
    <script src="../../Public/scripts/peliculas.js"></script>
    <script>
        traer_generos();
    </script>
</asp:Content>
