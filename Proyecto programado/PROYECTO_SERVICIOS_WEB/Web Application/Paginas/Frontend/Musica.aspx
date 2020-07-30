<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Frontend.Master" AutoEventWireup="true" CodeBehind="Musica.aspx.cs" Inherits="Web_Application.Paginas.Frontend.Musica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="/Paginas/Frontend/Index.aspx">Inicio</a></li>
            <li class="breadcrumb-item">Búsqueda</li>
            <li class="breadcrumb-item active" aria-current="page">Música</li>
        </ol>
    </nav>
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <br />
                <h3 class="text-uppercase text-muted">Búsqueda de Música</h3>
                <br />
                <label class="text-font-normal">Género</label>
                <div class="spinner-border text-primary input_musica_Genero_spinner" role="status">
                    <span class="sr-only">Loading...</span>
                </div>
                <select id="input_musica_Genero" class="form-control sm-1"></select>
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
                <button class="btn btn-outline-success my-2 my-sm-0" type="button" onclick="button_submit_musica_buscar()">Buscar</button>
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
    <script src="../../Public/scripts/musica.js"></script>
    <script>
        traer_generos();
    </script>
</asp:Content>
