<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Backend.Master" AutoEventWireup="true" CodeBehind="musicaAdmin.aspx.cs" Inherits="Web_Application.Paginas.Backend.musicaAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="../../Public/scripts/musicaAdmin.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
    <link rel="stylesheet" href="../../Public/estilos/estilo_global.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="./index.aspx">Inicio</a></li>
            <li class="breadcrumb-item active" aria-current="page">Administracion de musica</li>
        </ol>
    </nav>
<div style="background-image: url('../../Public/imagenes/fondo_general.png'); height: 1690px;" class="text-white">
    <div class="tp-3 mb-2 bg-dark text-white text-center text-uppercase font-weight-bold">
        Administracion de musica
    </div>

    <div class="container">
        <div class="titulo">
            Aquí puede administrar los recursos de musica
        </div>
        <br />
        <div id="boton_crear">
            <button class="btn btn-primary justify-content-center" type="button" onclick="contenedorCrear_visible('inline'); 
                contenedorTabla_visible('none'); 
                contenedorEditar_visible('none')">
                Crear nuevo registro</button>
        </div>
        <br />
        <div id="contenedor_tabla">
            Cargando...
            <div class="spinner-border text-primary" role="status">
                <span class="sr-only">Loading...</span>
            </div>
        </div>

        <div id="contenedor_editar">
            <div class="titulo">
                Editando musica
            </div>
            <div class="row">
                <div class="col-12 col-sm-12 col-md-12 col-lg-6">


                    <label class="text-font-normal text-white" for="">ID:</label>
                    <br>
                    <input disabled type="text" name="" class="editar_id_musica form-control">
                    <br>
                    <label class="text-font-normal text-white" for="">Nombre:</label>
                    <br>
                    <input type="text" name="" class="editar_nombre_musica form-control">
                    <br>
                    <label class="text-font-normal text-white" for="">Genero:</label>
                    <br>
                    <select id="editarGenero" class="form-control editar_genero_musica"></select>
                    <br>
                    <label class="text-font-normal text-white" for="">Tipo interpretacion:</label>
                    <br>
                    <input type="text" name="" class="editar_tipoInterpretacion_musica form-control">
                    <br>
                    <label class="text-font-normal text-white" for="">Idioma:</label>
                    <br>
                    <input type="text" name="" class="editar_idioma_musica form-control">
                    <br>
                    <label class="text-font-normal text-white" for="">Pais:</label>
                    <br>
                    <input type="text" name="" class="editar_pais_musica form-control">
                    <br>
                    <label class="text-font-normal text-white" for="">Disquera:</label>
                    <br>
                    <input type="text" name="" class="editar_disquera_musica form-control">
                </div>
                <div class="col-12 col-sm-12 col-md-12 col-lg-6">
                    <label class="text-font-normal text-white" for="">Nombre del disco:</label>
                    <br>
                    <input type="text" name="" class="editar_nombreDisco_musica form-control">
                    <br />
                    <label class="text-font-normal text-white" for="">Año:</label>
                    <br>
                    <input type="text" name="" class="editar_anio_musica form-control">
                    <br>
                    <label class="text-font-normal text-white" for="">Monto:</label>
                    <br>
                    <input type="number" name="" class="editar_monto_musica form-control">
                    <br>
                    <label class="text-font-normal text-white" for="">Nombre archivo descarga:</label>
                    <br>
                    <input type="text" name="" id="editarNombreDescargaMusica" class="editar_nombre_descarga_musica form-control" runat="server">
                    <br>
                    <label class="text-font-normal text-white" for="">Archivo musica:</label>
                    <br>
                    <input id="editarArchivoMusica" class="editar_archivo_musica form-control" type="file" accept=".mp3,audio/*" runat="server" />
                    <br>
                    <label class="text-font-normal text-white" for="">Nombre archivo previsualizacion:</label>
                    <br>
                    <input type="text" name="" id="editarNombrePrevisualizacionMusica" class="editar_nombre_previsualizacion_musica form-control" runat="server">
                    <br>
                    <label class="text-font-normal text-white" for="">Archivo musica previsualizacion:</label>
                    <br>
                    <input id="editarArchivoMusicaPrev" class="editar_archivo_musica_prev form-control" type="file" accept=".mp3,audio/*" runat="server" />
                </div>

            </div>
            <br />
            <button class="btn btn-primary btn-block" type="button" onclick="guardar_cambios()">Guardar cambios</button>
            <button class="btn btn-primary btn-block">Cancelar</button>
            <br />
        </div>

        <div id="contenedor_crear">
            <div class="titulo">
                Creando nueva música
            </div>
            <div class="row">
                <div class="col-12 col-sm-12 col-md-12 col-lg-6">
                    <label class="text-font-normal text-white" for="">Nombre:</label>
                    <br>
                    <input type="text" name="" class="crear_nombre_musica form-control">
                    <br>
                    <label class="text-font-normal text-white" for="">Genero:</label>
                    <br>
                    <select id="crearGenero" class="form-control crear_genero_musica"></select>
                    <br>
                    <label class="text-font-normal text-white" for="">Tipo interpretacion:</label>
                    <br>
                    <input type="text" name="" class="crear_tipoInterpretacion_musica form-control">
                    <br>
                    <label class="text-font-normal text-white" for="">Idioma:</label>
                    <br>
                    <input type="text" name="" class="crear_idioma_musica form-control">
                    <br>
                    <label class="text-font-normal text-white" for="">Pais:</label>
                    <br>
                    <input type="text" name="" class="crear_pais_musica form-control">
                    <br>
                    <label class="text-font-normal text-white" for="">Disquera:</label>
                    <br>
                    <input type="text" name="" class="crear_disquera_musica form-control">
                <br />
                    <label class="text-font-normal text-white" for="">Nombre del disco:</label>
                    <br>
                    <input type="text" name="" class="crear_nombreDisco_musica form-control">
                    </div>
                <div class="col-12 col-sm-12 col-md-12 col-lg-6">
                    <label class="text-font-normal text-white" for="">Año:</label>
                    <br>
                    <input type="text" name="" class="crear_anio_musica form-control">
                    <br />
                    <label class="text-font-normal text-white" for="">Monto:</label>
                    <br>
                    <input type="number" name="" class="crear_monto_musica form-control">
                    <br>
                    <label class="text-font-normal text-white" for="">Nombre archivo musica:</label>
                    <br>
                    <input type="text" name="" id="nombreArchivoMusica" class="nombre_archivo_musica form-control" runat="server">
                    <br>
                    <label class="text-font-normal text-white" for="">Archivo musica:</label>
                    <br>
                    <input id="archivoMusica" class="archivo_musica form-control" type="file" accept=".mp3,audio/*" runat="server" />
                    <br>
                    <label class="text-font-normal text-white" for="">Nombre archivo previsualizacion:</label>
                    <br>
                    <input type="text" id="nombrePrevisualizacionMusica" class="nombre_previsualizacion_musica form-control" runat="server">
                    <br>
                    <label class="text-font-normal text-white" for="">Archivo musica previsualizacion:</label>
                    <br>
                    <input id="archivoMusicaPrev" class="archivo_musica_prev form-control" type="file" accept=".mp3,audio/*" runat="server" />
                </div>
            </div>
            <br>
            <button class="btn btn-primary btn-block" type="button" onclick="crear_elemento()">Crear nueva musica</button>
            <button class="btn btn-primary btn-block">Cancelar</button>
            <br />
        </div>
    </div>
</div>



    <%--hidden elements--%>
    <asp:Button class="descargar_archivo_musica" ID="descargarArchivoMusica" runat="server" Text="" OnClick="subirArchivosMusica_Click" Style="display: none" />
    <asp:Button class="eliminar_archivo_musica" ID="eliminarArchivoMusica" runat="server" Text="" OnClick="eliminarArchivoMusica_Click" Style="display: none" />
    <asp:Button class="editar_archivos_musica" ID="editarArchivosMusica" runat="server" Text="" OnClick="editarArchivosMusica_Click" Style="display: none" />
    <input type="text" name="" id="viejoNombreDescargaMusica" class="viejo_nombre_descarga_musica" runat="server" style="display: none">
    <input type="text" name="" id="viejoNombrePrevisualizacionMusica" class="viejo_nombre_previsualizacion_musica" runat="server" style="display: none">

    <script>
        cargar_elementos();
        traer_generos();
        contenedorTabla_visible("inline");
        contenedorEditar_visible("none");
        contenedorCrear_visible("none");
    </script>
</asp:Content>
