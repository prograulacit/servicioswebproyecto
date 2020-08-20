<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Frontend.Master" AutoEventWireup="true" CodeBehind="Musica.aspx.cs" Inherits="Web_Application.Paginas.Frontend.Musica" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../../Public/estilos/estilo_global.css">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="/Paginas/Frontend/Index.aspx">Inicio</a></li>
            <li class="breadcrumb-item">Búsqueda</li>
            <li class="breadcrumb-item active" aria-current="page">Música</li>
        </ol>
    </nav>
<div style="background-image: url('https://localhost:44371/Public/imagenes/fondo_general.png'); height: 1207px;" class="text-white">
    <div class="container" id="main_container">
        <div class="row justify-content-center">
            <div class="form-group col-4">
                <br />
                <h3 class="p-3 mb-2 bg-dark text-white text-center text-uppercase font-weight-bold">Búsqueda de Música</h3>
                <br />
                <label class="text-font-normal">Género</label>
                <div class="spinner-border text-primary input_musica_Genero_spinner" role="status">
                    <span class="sr-only">Loading...</span>
                </div>
                <select id="input_musica_Genero" class="form-control"></select>
                <br />
                <label class="text-font-normal">Nombre</label>
                <input type="text" id="input_musica_Nombre" placeholder="Nombre" class="form-control" aria-label="Search" />
                <br />
                <label class="text-font-normal">Tipo</label>
                <input type="text" id="input_musica_Tipo" placeholder="Tipo" class="form-control" aria-label="Search" />
                <br />
                <label class="text-font-normal">Idioma</label>
                <input type="text" id="input_musica_Idioma" placeholder="Idioma" class="form-control" aria-label="Search" />
                <br />
                <label class="text-font-normal">País</label>
                <input type="text" id="input_musica_Pais" placeholder="Pais" class="form-control" aria-label="Search" />
                <br />
                <label class="text-font-normal">Disquera</label>
                <input type="text" id="input_musica_Disquera" placeholder="Disquera" class="form-control" aria-label="Search" />
                <br />
                <label class="text-font-normal">Disco</label>
                <input type="text" id="input_musica_Disco" placeholder="Disco" class="form-control" aria-label="Search" />
                <br />
                <label class="text-font-normal">Año</label>
                <input type="text" id="input_musica_Anio" placeholder="Año" class="form-control" aria-label="Search" />
                <br />
                <button class="btn btn-primary justify-content-center" type="button" onclick="button_submit_musica_buscar()">Buscar</button>
            </div>
            <div class="col-md-8">
                <br />
                <br />
                <br />
                <br />
                <div id="tabla_Musica"></div>
            </div>
        </div>
    </div>
    <div id="audio_container" class="container" style="display:none">	
        <div class="column">	
            <a href="#" class="btn btn-secondary mb-4" onclick="ir_a_tabla()">Atras</a>	
            <div>	
                <audio id="musica_player" controls="controls"></audio>	
            </div>	
        </div>	
    </div>
</div>
    <script src="../../Public/scripts/musica.js"></script>
    <script src="../../Public/scripts/productoCompra.js"></script>
    <script>
        traer_generos();
    </script>
</asp:Content>
