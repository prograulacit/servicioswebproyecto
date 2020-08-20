<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Backend.Master" AutoEventWireup="true" CodeBehind="peliculasAdmin.aspx.cs" Inherits="Web_Application.Paginas.Backend.peliculasAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Public/scripts/peliculasAdmin.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
    <link rel="stylesheet" href="../../Public/estilos/estilo_global.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="./index.aspx">Inicio</a></li>
            <li class="breadcrumb-item active" aria-current="page">Administración de péliculas</li>
        </ol>
    </nav>
<div style="background-image: url('../../Public/imagenes/fondo_general.png'); height: 1404px;" class="text-white">
    <div class="container">

        <div class="tp-3 mb-2 bg-dark text-white text-center text-uppercase font-weight-bold">
            Administracion de péliculas
        </div>

        <div class="titulo">
            Aquí puede administrar los recursos de péliculas
        </div>

        <div id="boton_crear">
            <button class="btn btn-primary" type="button" onclick="contenedorCrear_visible('inline'); 
                contenedorTabla_visible('none'); 
                contenedorEditar_visible('none')">
                Crear nuevo registro</button>
        </div>
        <br />
        <div class="row text-white">
            <div id="contenedor_tabla">
                Cargando...
                <div class="spinner-border text-primary" role="status">
                    <span class="sr-only">Loading...</span>
                </div>
            </div>
        </div>

        <div id="contenedor_editar">
            <div class="titulo">
                Editando pelicula
            </div>
            <div class="row">
                <div class="col-12 col-sm-12 col-md-12 col-lg-6">
                    <label class="text-font-normal text-white">ID:</label>
                    <br>
                    <input disabled type="text" name="" class="editar_id form-control">
                    <br>
                    <label class="text-font-normal text-white">Nombre:</label>
                    <br>
                    <input type="text" name="" class="editar_nombre form-control">
                    <br>
                    <label class="text-font-normal text-white">Genero:</label>
                    <br>
                    <select id="editarGenero" class="form-control editar_genero"></select>
                    <br>
                    <label class="text-font-normal text-white">Año:</label>
                    <br>
                    <input type="text" name="" class="editar_anio form-control">
                    <br>
                    <label class="text-font-normal text-white">Idioma:</label>
                    <br>
                    <input type="text" name="" class="editar_idioma form-control">
                    <br>
                    <label class="text-font-normal text-white">Actores:</label>
                    <br>
                    <input type="text" name="" class="editar_actores form-control">
                </div>
                <div class="col-12 col-sm-12 col-md-12 col-lg-6">
                    <label class="text-font-normal text-white">Monto:</label>
                    <br>
                    <input type="number" name="" class="editar_monto form-control">
                    <br>
                    <label class="text-font-normal text-white">Nombre archivo descarga:</label>
                    <br>
                    <input type="text" name="" id="editarNombreDescargaPelicula" class="editar_nombre_descarga_pelicula form-control" runat="server">
                    <br>
                    <label class="text-font-normal text-white">Archivo Pelicula:</label>
                    <br>
                    <input id="editarArchivoPelicula" class="editar_archivo_pelicula form-control" type="file" accept=".mp4,video/*" runat="server" />
                    <br>
                    <label class="text-font-normal text-white">Nombre archivo previsualizacion:</label>
                    <br>
                    <input type="text" name="" id="editarNombrePrevisualizacionPelicula" class="editar_nombre_previsualizacion_pelicula form-control" runat="server">
                    <br>
                    <label class="text-font-normal text-white">Archivo Pelicula previsualizacion:</label>
                    <br>
                    <input id="editarArchivoPeliculaPrev" class="editar_archivo_pelicula_prev form-control" type="file" accept=".mp4,video/*" runat="server" />
                    <br>
                </div>
            </div>
            <br />
            <button class="btn btn-primary btn-block btn-sm" type="button" onclick="guardar_cambios()">Guardar cambios</button>
            <button class="btn btn-primary btn-block btn-sm">Cancelar</button>
            <br />
        </div>

        <div id="contenedor_crear">
            <div class="subtitulo">
                Nueva pélicula
            </div>
            <div class="row">
                <div class="col-12 col-sm-12 col-md-12 col-lg-6">
                    <label class="text-font-normal text-white">Nombre:</label>
                    <br>
                    <input type="text" name="" class="crear_nombre form-control">
                    <br>
                    <label class="text-font-normal text-white">Genero:</label>
                    <br>
                    <select id="crearGenero" class="form-control crear_genero form-control"></select>
                    <br>
                    <label class="text-font-normal text-white">Año:</label>
                    <br>
                    <input type="text" name="" class="crear_anio form-control">
                    <br>
                    <label class="text-font-normal text-white">Idioma:</label>
                    <br>
                    <input type="text" name="" class="crear_idioma form-control">
                    <br>
                    <label class="text-font-normal text-white">Actores:</label>
                    <br>
                    <input type="text" name="" class="crear_actores form-control">
                </div>
                <div class="col-12 col-sm-12 col-md-12 col-lg-6">
                    <label class="text-font-normal text-white">Monto:</label>
                    <br>
                    <input type="number" name="" class="crear_monto form-control">
                    <br>
                    <label class="text-font-normal text-white">Nombre archivo descarga:</label>
                    <br>
                    <input type="text" name="" id="nombreArchivoPelicula" class="nombre_archivo_pelicula form-control" runat="server">
                    <br>
                    <label class="text-font-normal text-white">Archivo Pelicula:</label>
                    <br>
                    <input id="archivoPelicula" class="archivo_pelicula form-control" type="file" accept=".mp4,video/*" runat="server" />
                    <br>
                    <label class="text-font-normal text-white">Nombre archivo previsualizacion:</label>
                    <br>
                    <input type="text" id="nombrePrevisualizacionPelicula" class="nombre_previsualizacion_pelicula form-control" runat="server">
                    <br>
                    <label class="text-font-normal text-white">Archivo Pelicula previsualizacion:</label>
                    <br>
                    <input id="archivoPeliculaPrev" class="archivo_pelicula_prev form-control" type="file" accept=".mp4,video/*" runat="server" />
                </div>
            </div>
            <br />
            <button class="btn btn-primary btn-block btn-sm" type="button" onclick="crear_elemento()">Crear nueva pelicula</button>
            <button class="btn btn-primary btn-block btn-sm">Cancelar</button>
            <br />
        </div>
    </div>
</div>

    <%--hidden elements--%>
    <asp:Button class="descargar_archivo_pelicula" ID="descargarArchivoPelicula" runat="server" Text="" OnClick="subirArchivosPelicula_Click" Style="display: none" />
    <asp:Button class="eliminar_archivo_pelicula" ID="eliminarArchivoPelicula" runat="server" Text="" OnClick="eliminarArchivoPelicula_Click" Style="display: none" />
    <asp:Button class="editar_archivos_pelicula" ID="editarArchivosPelicula" runat="server" Text="" OnClick="editarArchivosPelicula_Click" Style="display: none" />
    <input type="text" name="" id="viejoNombreDescargaPelicula" class="viejo_nombre_descarga_pelicula" runat="server" style="display: none">
    <input type="text" name="" id="viejoNombrePrevisualizacionPelicula" class="viejo_nombre_previsualizacion_pelicula" runat="server" style="display: none">

    <script>
        cargar_elementos();
        traer_generos();
        contenedorTabla_visible("inline");
        contenedorEditar_visible("none");
        contenedorCrear_visible("none");
    </script>
</asp:Content>
