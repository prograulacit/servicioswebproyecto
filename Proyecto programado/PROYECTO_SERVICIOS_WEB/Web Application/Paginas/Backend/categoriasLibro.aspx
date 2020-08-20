<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Backend.Master" AutoEventWireup="true" CodeBehind="categoriasLibro.aspx.cs" Inherits="Web_Application.Paginas.Backend.categoriasLibro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Public/scripts/categoriasLibro.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="./index.aspx">Inicio</a></li>
            <li class="breadcrumb-item active" aria-current="page">Categorias libros</li>
        </ol>
    </nav>
        <link rel="stylesheet" href="../../Public/estilos/tarjetas.css">
<div style="background-image: url('../../Public/imagenes/fondo_general.png'); height: 1100px;">
    <div class="tp-3 mb-2 bg-dark text-white text-center text-uppercase font-weight-bold">
        Administracion de categorias de libro
    </div>

    <div class="container">
        <div class="titulo">
            Utilice los controles para administrar
        </div>
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-4">
                <div class="shadow-lg p-3 mb-5 bg-white rounded">
                    <div class="subtitulo">Ingresar categoria nuevo</div>
                    <input class="form-control" type="text" name="ingresar_categoria_contenido" id="input_elementoNuevo">
                    <br />
                    <button class="btn btn-primary btn-block" type="button" onclick="ingresar_elemento()">Guardar</button>
                </div>
                <div class="shadow-lg p-3 mb-5 bg-white rounded">
                    <div class="subtitulo">Editar categoria</div>
                    <label class="text-font-normal" for="">ID</label>

                    <input class="form-control" type="text" name="actualizar_categoria_id" id="inputId_elementoActualizar">

                    <label class="text-font-normal" for="">Nueva categoria</label>

                    <input class="form-control" type="text" name="actualizar_genero_contenido" id="inputContenido_elementoActualizar">
                    <br>
                    <button class="btn btn-primary btn-block" type="button" onclick="actualizar_elemento()">Actualizar</button>
                </div>
                <div class="shadow-lg p-3 mb-5 bg-white rounded">
                    <div class="subtitulo">Eliminar categoria</div>
                    <label class="text-font-normal" for="">ID</label>

                    <input class="form-control" type="text" name="eliminar_datos" id="inputId_elementoEliminar">
                    <br />
                    <button class="btn btn-danger btn-block" type="button" onclick="eliminar_elemento()">Eliminar</button>
                </div>
            </div>
            <div class="col-12 col-sm-12 col-md-12 col-lg-8 text-white">
                <div id="http_response_contenido">
                    <div class="spinner-border text-primary" role="status">
                        <span class="sr-only">Loading...</span>
                    </div>
                    Cargando...
                </div>
            </div>
        </div>
        </div>
</div>
        <script>
            obtener_elementos();
        </script>
</asp:Content>
