<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Backend.Master" AutoEventWireup="true" CodeBehind="musicaAdmin.aspx.cs" Inherits="Web_Application.Paginas.Backend.musicaAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="../../Public/scripts/musicaAdmin.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="./index.aspx">Inicio</a></li>
            <li class="breadcrumb-item active" aria-current="page">Administracion de musica</li>
        </ol>
    </nav>
    <div class="tp-3 mb-2 bg-dark text-white text-center text-uppercase font-weight-bold">
        Administracion de musica
    </div>

    <div class="text-font-normal">
        Aquí puede administrar los recursos de musica
    </div>
    <br />
    <div id="boton_crear">
        <button class="btn btn-primary justify-content-center" type="button" onclick="contenedorCrear_visible('inline'); 
        contenedorTabla_visible('none'); 
        contenedorEditar_visible('none')">Crear nuevo registro</button>
    </div>

    <div id="contenedor_tabla">
        Cargando...
        <div class="spinner-border text-primary" role="status">
            <span class="sr-only">Loading...</span>
        </div>
    </div>

    <div class="container">
        <div class="row justify-content-center">
            <div class="form-group col-4">
                <div id="contenedor_editar">
                    <div class="titulo">
                        Editando musica
                    </div>
                    <label class="text-font-normal" for="">ID:</label>
                    <br>
                    <input disabled type="text" name="" class="editar_id_musica form-control">
                    <br>
                    <label class="text-font-normal" for="">Nombre:</label>
                    <br>
                    <input type="text" name="" class="editar_nombre_musica form-control">
                    <br>
                    <label class="text-font-normal" for="">Genero:</label>
                    <br>
                    <select id="editarGenero" class="form-control editar_genero_musica"></select>
                    <br>
                    <label class="text-font-normal" for="">Tipo interpretacion:</label>
                    <br>
                    <input type="text" name="" class="editar_tipoInterpretacion_musica form-control">
                    <br>
                    <label class="text-font-normal" for="">Idioma:</label>
                    <br>
                    <input type="text" name="" class="editar_idioma_musica form-control">
                    <br>
                    <label class="text-font-normal" for="">Pais:</label>
                    <br>
                    <input type="text" name="" class="editar_pais_musica form-control">
                    <br>
                    <label class="text-font-normal" for="">Disquera:</label>
                    <br>
                    <input type="text" name="" class="editar_disquera_musica form-control">
                    <br>
                    <label class="text-font-normal" for="">Nombre del disco:</label>
                    <br>
                    <input type="text" name="" class="editar_nombreDisco_musica form-control">
                    <br>
                    <label class="text-font-normal" for="">Año:</label>
                    <br>
                    <input type="text" name="" class="editar_anio_musica form-control">
                    <br>
                    <label class="text-font-normal" for="">Monto:</label>
                    <br>
                    <input type="number" name="" class="editar_monto_musica form-control">
                    <br>
                    <label class="text-font-normal" for="">Nombre archivo descarga:</label>
                    <br>
                    <input type="text" name="" id="editarNombreDescargaMusica" class="editar_nombre_descarga_musica form-control" runat="server">
                     <br>
                    <label class="text-font-normal" for="">Archivo musica:</label>
                    <br>
                    <input id="editarArchivoMusica" class="editar_archivo_musica form-control" type="file" accept=".mp3,audio/*" runat="server"/>
                    <br>
                    <label class="text-font-normal" for="">Nombre archivo previsualizacion:</label>
                    <br>
                    <input type="text" name="" id="editarNombrePrevisualizacionMusica" class="editar_nombre_previsualizacion_musica form-control" runat="server">
                    <br>
                    <label class="text-font-normal" for="">Archivo musica previsualizacion:</label>
                    <br>
                    <input id="editarArchivoMusicaPrev" class="editar_archivo_musica_prev form-control" type="file" accept=".mp3,audio/*" runat="server"/>
                    <br>
                    <button class="btn btn-primary justify-content-center" type="button" onclick="guardar_cambios()">Guardar cambios</button>
                    <button class="btn btn-primary justify-content-center">Cancelar</button>
                </div>
                <br />
                <br />
                <br />
                <div id="contenedor_crear">
                    <label class="text-font-normal" for="">Nombre:</label>
                    <br>
                    <input type="text" name="" class="crear_nombre_musica form-control">
                    <br>
                    <label class="text-font-normal" for="">Genero:</label>
                    <br>
                    <select id="crearGenero" class="form-control crear_genero_musica"></select>
                    <br>
                    <label class="text-font-normal" for="">Tipo interpretacion:</label>
                    <br>
                    <input type="text" name="" class="crear_tipoInterpretacion_musica form-control">
                    <br>
                    <label class="text-font-normal" for="">Idioma:</label>
                    <br>
                    <input type="text" name="" class="crear_idioma_musica form-control">
                    <br>
                    <label class="text-font-normal" for="">Pais:</label>
                    <br>
                    <input type="text" name="" class="crear_pais_musica form-control">
                    <br>
                    <label class="text-font-normal" for="">Disquera:</label>
                    <br>
                    <input type="text" name="" class="crear_disquera_musica form-control">
                    <br>
                    <label class="text-font-normal" for="">Nombre del disco:</label>
                    <br>
                    <input type="text" name="" class="crear_nombreDisco_musica form-control">
                    <br>
                    <label class="text-font-normal" for="">Año:</label>
                    <br>
                    <input type="text" name="" class="crear_anio_musica form-control">
                    <br>
                    <label class="text-font-normal" for="">Monto:</label>
                    <br>
                    <input type="number" name="" class="crear_monto_musica form-control">
                    <br>
                    <label class="text-font-normal" for="">Nombre archivo musica:</label>
                    <br>
                    <input type="text" name="" id="nombreArchivoMusica" class="nombre_archivo_musica form-control" runat="server">
                    <br>
                    <label class="text-font-normal" for="">Archivo musica:</label>
                    <br>
                    <input id="archivoMusica" class="archivo_musica form-control" type="file" accept=".mp3,audio/*" runat="server"/>
                    <br>
                    <label class="text-font-normal" for="">Nombre archivo previsualizacion:</label>
                    <br>
                    <input type="text" id="nombrePrevisualizacionMusica" class="nombre_previsualizacion_musica form-control" runat="server">
                    <br>
                    <label class="text-font-normal" for="">Archivo musica previsualizacion:</label>
                    <br>
                    <input id="archivoMusicaPrev" class="archivo_musica_prev form-control" type="file" accept=".mp3,audio/*" runat="server"/>
                    <br>
                    <button class="btn btn-primary justify-content-center" type="button" onclick="crear_elemento()">Crear nueva musica</button>
                    <button class="btn btn-primary justify-content-center">Cancelar</button>
                </div>
            </div>
        </div>
    </div>

    
    <%--hidden elements--%>
    <asp:Button class="descargar_archivo_musica" id="descargarArchivoMusica" runat="server" Text="" OnClick="subirArchivosMusica_Click" style="display:none"/>
    <asp:Button class="eliminar_archivo_musica" id="eliminarArchivoMusica" runat="server" Text="" OnClick="eliminarArchivoMusica_Click" style="display:none"/>
    <asp:Button class="editar_archivos_musica" id="editarArchivosMusica" runat="server" Text="" OnClick="editarArchivosMusica_Click" style="display:none"/>
    <input type="text" name="" id="viejoNombreDescargaMusica" class="viejo_nombre_descarga_musica" runat="server" style="display:none">
    <input type="text" name="" id="viejoNombrePrevisualizacionMusica" class="viejo_nombre_previsualizacion_musica" runat="server" style="display:none">

    <script>
        cargar_elementos();
        traer_generos();
        contenedorTabla_visible("inline");
        contenedorEditar_visible("none");
        contenedorCrear_visible("none");
    </script>
</asp:Content>
