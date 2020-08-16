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
    <div class="tp-3 mb-2 bg-dark text-white text-center text-uppercase font-weight-bold">
        Administracion de libros
    </div>

    <div class="container">
        <div class="titulo">
            Aquí puede administrar los recursos de libros (PDF)
        </div>
        <br />
        <div class="form-group col-4">
            <div id="boton_crear">
                <button class="btn btn-primary justify-content-center" type="button" onclick="contenedorCrear_visible('inline'); 
                    contenedorTabla_visible('none'); 
                    contenedorEditar_visible('none')">
                    Crear nuevo registro</button>
            </div>
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
            <div class="row">
                <div class="col-12 col-sm-12 col-md-12 col-lg-6">
                    <label class="text-font-normal" for="">ID:</label>
                    <br>
                    <input disabled type="text" name="" class="editar_id form-control">
                    <br>
                    <label class="text-font-normal" for="">Nombre:</label>
                    <br>
                    <input type="text" name="" class="editar_nombre form-control">
                    <br>
                    <label class="text-font-normal" for="">Categoria:</label>
                    <br>
                    <select id="editarCategoria" class="form-control editar_categoria"></select>
                    <br>
                    <label class="text-font-normal" for="">Autor:</label>
                    <br>
                    <input type="text" name="" class="editar_autor form-control">
                    <br>
                    <label class="text-font-normal" for="">Idioma:</label>
                    <br>
                    <input type="text" name="" class="editar_idioma form-control">
                    <br>
                    <label class="text-font-normal" for="">Editorial:</label>
                    <br>
                    <input type="text" name="" class="editar_editorial form-control">
                </div>
                <div class="col-12 col-sm-12 col-md-12 col-lg-6">
                    <label class="text-font-normal" for="">Año de publicación:</label>
                    <br>
                    <input type="text" name="" class="editar_anioPublicacion form-control">
                    <br>
                    <label class="text-font-normal" for="">Monto:</label>
                    <br>
                    <input type="number" name="" class="editar_monto form-control">
                    <br>
                    <label class="text-font-normal" for="">Nombre archivo descarga:</label>
                    <br>
                    <input type="text" name="" id="editarNombreDescargaLibro" class="editar_nombre_descarga_libro form-control" runat="server">
                    <br>
                    <label class="text-font-normal" for="">Archivo Libro:</label>
                    <br>
                    <input id="editarArchivoLibro" class="editar_archivo_libro form-control" type="file" accept="application/pdf" runat="server" />
                    <br>
                    <label class="text-font-normal" for="">Nombre archivo previsualizacion:</label>
                    <br>
                    <input type="text" name="" id="editarNombrePrevisualizacionLibro" class="editar_nombre_previsualizacion_libro form-control" runat="server">
                    <br>
                    <label class="text-font-normal" for="">Archivo Libro previsualizacion:</label>
                    <br>
                    <input id="editarArchivoLibroPrev" class="editar_archivo_libro_prev form-control" type="file" accept="application/pdf" runat="server" />
                </div>
            </div>
            <br>
            <button class="btn btn-primary btn-block" type="button" onclick="guardar_cambios()">Guardar cambios</button>
            <button class="btn btn-primary btn-block">Cancelar</button>
            <br>
        </div>

        <div id="contenedor_crear">
            <div class="titulo">
                Crear nuevo libro
            </div>
            <div class="row">

                <div class="col-12 col-sm-12 col-md-12 col-lg-6">
                    <label class="text-font-normal" for="">Nombre:</label>
                    <br>
                    <input type="text" name="" class="crear_nombre form-control">
                    <br>
                    <label class="text-font-normal" for="">Categoria:</label>
                    <br>
                    <select id="crearCategoria" class="form-control crear_categoria"></select>
                    <br>
                    <label class="text-font-normal" for="">Autor:</label>
                    <br>
                    <input type="text" name="" class="crear_autor form-control">
                    <br>
                    <label class="text-font-normal" for="">Idioma:</label>
                    <br>
                    <input type="text" name="" class="crear_idioma form-control">
                    <br>
                    <label class="text-font-normal" for="">Editorial:</label>
                    <br>
                    <input type="text" name="" class="crear_editorial form-control">
                    <br>
                    <label class="text-font-normal" for="">Año de publicación:</label>
                <br />
                    <input type="text" name="" class="crear_anioPublicacion form-control">
                    </div>
                <div class="col-12 col-sm-12 col-md-12 col-lg-6">
                    <label class="text-font-normal" for="">Monto:</label>
                    <br>
                    <input type="number" name="" class="crear_monto form-control">
                    <br>
                    <label class="text-font-normal" for="">Nombre archivo Libro:</label>
                    <br>
                    <input type="text" name="" id="nombreArchivoLibro" class="nombre_archivo_libro form-control" runat="server">
                    <br>
                    <label class="text-font-normal" for="">Archivo Libro:</label>
                    <br>
                    <input id="archivoLibro" class="archivo_libro form-control" type="file" accept="application/pdf" runat="server" />
                    <br>
                    <label class="text-font-normal" for="">Nombre archivo previsualizacion:</label>
                    <br>
                    <input type="text" id="nombrePrevisualizacionLibro" class="nombre_previsualizacion_libro form-control" runat="server">
                    <br>
                    <label class="text-font-normal" for="">Archivo Libro previsualizacion:</label>
                    <br>
                    <input id="archivoLibroPrev" class="archivo_libro_prev form-control" type="file" accept="application/pdf" runat="server" />
                </div>
            </div>
            <br>
            <button class="btn btn-primary btn-block" type="button" onclick="crear_elemento()">Crear nuevo libro</button>
            <button class="btn btn-primary btn-block">Cancelar</button>
            <br />
        </div>

        <%--hidden elements--%>
        <asp:Button class="descargar_archivo_libro btn btn-primary justify-content-center" ID="descargarArchivoLibro" runat="server" Text="" OnClick="subirArchivosLibro_Click" Style="display: none" />
        <asp:Button class="eliminar_archivo_libro btn btn-primary justify-content-center" ID="eliminarArchivoLibro" runat="server" Text="" OnClick="eliminarArchivoLibro_Click" Style="display: none" />
        <asp:Button class="editar_archivos_libro btn btn-primary justify-content-center" ID="editarArchivosLibro" runat="server" Text="" OnClick="editarArchivosLibro_Click" Style="display: none" />
        <input type="text" name="" id="viejoNombreDescargaLibro" class="viejo_nombre_descarga_libro" runat="server" style="display: none">
        <input type="text" name="" id="viejoNombrePrevisualizacionLibro" class="viejo_nombre_previsualizacion_libro" runat="server" style="display: none">

        <script>
            cargar_elementos();
            traer_categorias();
            contenedorTabla_visible("inline");
            contenedorEditar_visible("none");
            contenedorCrear_visible("none");
        </script>
</asp:Content>
