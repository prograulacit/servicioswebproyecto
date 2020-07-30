<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Backend.Master" AutoEventWireup="true" CodeBehind="peliculasAdmin.aspx.cs" Inherits="Web_Application.Paginas.Backend.peliculasAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Public/scripts/peliculasAdmin.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="titulo">
        Administracion de peliculas
    </div>

    <div class="descripcion">
        Aquí puede administrar los recursos de peliculas
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
            Editando pelicula
        </div>
        ID:
        <br>
        <input disabled type="text" name="" class="editar_id">
        <br>
        Nombre:
        <br>
        <input type="text" name="" class="editar_nombre">
        <br>
        Genero:
        <br>
        <input type="text" name="" class="editar_genero">
        <br>
        Año:
        <br>
        <input type="text" name="" class="editar_anio">
        <br>
        Idioma:
        <br>
        <input type="text" name="" class="editar_idioma">
        <br>
        Actores:
        <br>
        <input type="text" name="" class="editar_actores">
        <br>
        Monto:
        <br>
        <input type="number" name="" class="editar_monto">
        <br>
        Nombre archivo descarga:
        <br>
        <input type="text" name="" id="editarNombreDescargaPelicula" class="editar_nombre_descarga_pelicula" runat="server">
        <br>
        Archivo Pelicula:
        <br>
        <input id="editarArchivoPelicula" class="editar_archivo_pelicula" type="file" accept=".mp4,video/*" runat="server"/>
        <br>
        Nombre archivo previsualizacion:
        <br>
        <input type="text" name="" id="editarNombrePrevisualizacionPelicula" class="editar_nombre_previsualizacion_pelicula" runat="server">
        <br>
        Archivo Pelicula previsualizacion:
        <br>
        <input id="editarArchivoPeliculaPrev" class="editar_archivo_pelicula_prev" type="file" accept=".mp4,video/*" runat="server"/>
        <br>
        <button type="button" onclick="guardar_cambios()">Guardar cambios</button>
        <button>Cancelar</button>
    </div>

    <div id="contenedor_crear">
        Nombre:
        <br>
        <input type="text" name="" class="crear_nombre">
        <br>
        Genero:
        <br>
        <input type="text" name="" class="crear_genero">
        <br>
        Año:
        <br>
        <input type="text" name="" class="crear_anio">
        <br>
        Idioma:
        <br>
        <input type="text" name="" class="crear_idioma">
        <br>
        Actores:
        <br>
        <input type="text" name="" class="crear_actores">
        <br>
        Monto:
        <br>
        <input type="number" name="" class="crear_monto">
        <br>
        Nombre archivo descarga:
        <br>
        <input type="text" name="" id="nombreArchivoPelicula" class="nombre_archivo_pelicula" runat="server">
        <br>
        Archivo Pelicula:
        <br>
        <input id="archivoPelicula" class="archivo_pelicula" type="file" accept=".mp4,video/*" runat="server"/>
        <br>
        Nombre archivo previsualizacion:
        <br>
        <input type="text" id="nombrePrevisualizacionPelicula" class="nombre_previsualizacion_pelicula" runat="server">
        <br>
        Archivo Pelicula previsualizacion:
        <br>
        <input id="archivoPeliculaPrev" class="archivo_pelicula_prev" type="file" accept=".mp4,video/*" runat="server"/>
        <br>
        <button type="button" onclick="crear_elemento()">Crear nueva pelicula</button>
        <button>Cancelar</button>
    </div>

    <%--hidden elements--%>
    <asp:Button class="descargar_archivo_pelicula" id="descargarArchivoPelicula" runat="server" Text="" OnClick="subirArchivosPelicula_Click" style="display:none"/>
    <asp:Button class="eliminar_archivo_pelicula" id="eliminarArchivoPelicula" runat="server" Text="" OnClick="eliminarArchivoPelicula_Click" style="display:none"/>
    <asp:Button class="editar_archivos_pelicula" id="editarArchivosPelicula" runat="server" Text="" OnClick="editarArchivosPelicula_Click" style="display:none"/>
    <input type="text" name="" id="viejoNombreDescargaPelicula" class="viejo_nombre_descarga_pelicula" runat="server" style="display:none">
    <input type="text" name="" id="viejoNombrePrevisualizacionPelicula" class="viejo_nombre_previsualizacion_pelicula" runat="server" style="display:none">

    <script>
        cargar_elementos();
        contenedorTabla_visible("inline");
        contenedorEditar_visible("none");
        contenedorCrear_visible("none");
    </script>
</asp:Content>