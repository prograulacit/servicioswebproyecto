<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Backend.Master" AutoEventWireup="true" CodeBehind="libroAdmin.aspx.cs" Inherits="Web_Application.Paginas.Backend.libroAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Public/scripts/librosAdmin.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="./index.aspx">Inicio</a></li>
            <li class="breadcrumb-item active" aria-current="page">Administracion de libros</li>
        </ol>
    </nav>
    <div class="titulo">
        Administracion de libros
    </div>

    <div class="descripcion">
        Aquí puede administrar los recursos de libros (PDF)
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
            Editando libro
        </div>
        ID:
        <br>
        <input disabled type="text" name="" class="editar_id">
        <br>
        Nombre:
        <br>
        <input type="text" name="" class="editar_nombre">
        <br>
        Categoria:
        <br>
        <select id="editarCategoria" class="form-control sm-1 editar_categoria"></select>
        <br>
        Autor:
        <br>
        <input type="text" name="" class="editar_autor">
        <br>
        Idioma:
        <br>
        <input type="text" name="" class="editar_idioma">
        <br>
        Editorial:
        <br>
        <input type="text" name="" class="editar_editorial">
        <br>
        Año de publicación:
        <br>
        <input type="text" name="" class="editar_anioPublicacion">
        <br>
        Monto:
        <br>
        <input type="number" name="" class="editar_monto">
        <br>
        Nombre archivo descarga:
        <br>
        <input type="text" name="" id="editarNombreDescargaLibro" class="editar_nombre_descarga_libro" runat="server">
         <br>
        Archivo Libro:
        <br>
        <input id="editarArchivoLibro" class="editar_archivo_libro" type="file" accept="application/pdf" runat="server"/>
        <br>
        Nombre archivo previsualizacion:
        <br>
        <input type="text" name="" id="editarNombrePrevisualizacionLibro" class="editar_nombre_previsualizacion_libro" runat="server">
        <br>
        Archivo Libro previsualizacion:
        <br>
        <input id="editarArchivoLibroPrev" class="editar_archivo_libro_prev" type="file" accept="application/pdf" runat="server"/>
        <br>
        <button type="button" onclick="guardar_cambios()">Guardar cambios</button>
        <button>Cancelar</button>
    </div>

    <div id="contenedor_crear">
        Nombre:
        <br>
        <input type="text" name="" class="crear_nombre">
        <br>
        Categoria:
        <br>
        <select id="crearCategoria" class="form-control sm-1 crear_categoria"></select>
        <br>
        Autor:
        <br>
        <input type="text" name="" class="crear_autor">
        <br>
        Idioma:
        <br>
        <input type="text" name="" class="crear_idioma">
        <br>
        Editorial:
        <br>
        <input type="text" name="" class="crear_editorial">
        <br>
        Año de publicación:
        <br>
        <input type="text" name="" class="crear_anioPublicacion">
        <br>
        Monto:
        <br>
        <input type="number" name="" class="crear_monto">
        <br>
        Nombre archivo Libro:
        <br>
        <input type="text" name="" id="nombreArchivoLibro" class="nombre_archivo_libro" runat="server">
        <br>
        Archivo Libro:
        <br>
        <input id="archivoLibro" class="archivo_libro" type="file" accept="application/pdf" runat="server"/>
        <br>
        Nombre archivo previsualizacion:
        <br>
        <input type="text" id="nombrePrevisualizacionLibro" class="nombre_previsualizacion_libro" runat="server">
        <br>
        Archivo Libro previsualizacion:
        <br>
        <input id="archivoLibroPrev" class="archivo_libro_prev" type="file" accept="application/pdf" runat="server"/>
        <br>
        <button type="button" onclick="crear_elemento()">Crear nuevo libro</button>
        <button>Cancelar</button>
    </div>

    <%--hidden elements--%>
    <asp:Button class="descargar_archivo_libro" id="descargarArchivoLibro" runat="server" Text="" OnClick="subirArchivosLibro_Click" style="display:none"/>
    <asp:Button class="eliminar_archivo_libro" id="eliminarArchivoLibro" runat="server" Text="" OnClick="eliminarArchivoLibro_Click" style="display:none"/>
    <asp:Button class="editar_archivos_libro" id="editarArchivosLibro" runat="server" Text="" OnClick="editarArchivosLibro_Click" style="display:none"/>
    <input type="text" name="" id="viejoNombreDescargaLibro" class="viejo_nombre_descarga_libro" runat="server" style="display:none">
    <input type="text" name="" id="viejoNombrePrevisualizacionLibro" class="viejo_nombre_previsualizacion_libro" runat="server" style="display:none">

    <script>
        cargar_elementos();
        traer_categorias();
        contenedorTabla_visible("inline");
        contenedorEditar_visible("none");
        contenedorCrear_visible("none");
    </script>
</asp:Content>
