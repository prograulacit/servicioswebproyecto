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
    <div class="titulo">
        Administracion de musica
    </div>

    <div class="descripcion">
        Aquí puede administrar los recursos de musica
    </div>

    <div id="boton_crear">
        <button type="button" onclick="contenedorCrear_visible('inline'); 
        contenedorTabla_visible('none'); 
        contenedorEditar_visible('none')">Crear nuevo registro</button>
    </div>

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
        ID:
        <br>
        <input disabled type="text" name="" class="editar_id_musica">
        <br>
        Nombre:
        <br>
        <input type="text" name="" class="editar_nombre_musica">
        <br>
        Genero:
        <br>
        <select id="editarGenero" class="form-control sm-1 editar_genero_musica"></select>
        <br>
        Tipo interpretacion:
        <br>
        <input type="text" name="" class="editar_tipoInterpretacion_musica">
        <br>
        Idioma:
        <br>
        <input type="text" name="" class="editar_idioma_musica">
        <br>
        Pais:
        <br>
        <input type="text" name="" class="editar_pais_musica">
        <br>
        Disquera:
        <br>
        <input type="text" name="" class="editar_disquera_musica">
        <br>
        Nombre del disco:
        <br>
        <input type="text" name="" class="editar_nombreDisco_musica">
        <br>
        Año:
        <br>
        <input type="text" name="" class="editar_anio_musica">
        <br>
        Monto:
        <br>
        <input type="number" name="" class="editar_monto_musica">
        <br>
        Nombre archivo descarga:
        <br>
        <input type="text" name="" id="editarNombreDescargaMusica" class="editar_nombre_descarga_musica" runat="server">
         <br>
        Archivo musica:
        <br>
        <input id="editarArchivoMusica" class="editar_archivo_musica" type="file" accept=".mp3,audio/*" runat="server"/>
        <br>
        Nombre archivo previsualizacion:
        <br>
        <input type="text" name="" id="editarNombrePrevisualizacionMusica" class="editar_nombre_previsualizacion_musica" runat="server">
        <br>
        Archivo musica previsualizacion:
        <br>
        <input id="editarArchivoMusicaPrev" class="editar_archivo_musica_prev" type="file" accept=".mp3,audio/*" runat="server"/>
        <br>
        <button type="button" onclick="guardar_cambios()">Guardar cambios</button>
        <button>Cancelar</button>
    </div>

    <div id="contenedor_crear">
        Nombre:
        <br>
        <input type="text" name="" class="crear_nombre_musica">
        <br>
        Genero:
        <br>
        <select id="crearGenero" class="form-control sm-1 crear_genero_musica"></select>
        <br>
        Tipo interpretacion:
        <br>
        <input type="text" name="" class="crear_tipoInterpretacion_musica">
        <br>
        Idioma:
        <br>
        <input type="text" name="" class="crear_idioma_musica">
        <br>
        Pais:
        <br>
        <input type="text" name="" class="crear_pais_musica">
        <br>
        Disquera:
        <br>
        <input type="text" name="" class="crear_disquera_musica">
        <br>
        Nombre del disco:
        <br>
        <input type="text" name="" class="crear_nombreDisco_musica">
        <br>
        Año:
        <br>
        <input type="text" name="" class="crear_anio_musica">
        <br>
        Monto:
        <br>
        <input type="number" name="" class="crear_monto_musica">
        <br>
        Nombre archivo musica:
        <br>
        <input type="text" name="" id="nombreArchivoMusica" class="nombre_archivo_musica" runat="server">
        <br>
        Archivo musica:
        <br>
        <input id="archivoMusica" class="archivo_musica" type="file" accept=".mp3,audio/*" runat="server"/>
        <br>
        Nombre archivo previsualizacion:
        <br>
        <input type="text" id="nombrePrevisualizacionMusica" class="nombre_previsualizacion_musica" runat="server">
        <br>
        Archivo musica previsualizacion:
        <br>
        <input id="archivoMusicaPrev" class="archivo_musica_prev" type="file" accept=".mp3,audio/*" runat="server"/>
        <br>
        <button type="button" onclick="crear_elemento()">Crear nueva musica</button>
        <button>Cancelar</button>
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
