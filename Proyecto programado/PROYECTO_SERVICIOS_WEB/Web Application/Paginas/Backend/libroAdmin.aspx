<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Backend.Master" AutoEventWireup="true" CodeBehind="libroAdmin.aspx.cs" Inherits="Web_Application.Paginas.Backend.libroAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Public/scripts/libroAdmin.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        <input type="text" name="" id="editar_id">
        <br>
        Nombre:
        <br>
        <input type="text" name="" id="editar_nombre">
        <br>
        Categoria:
        <br>
        <input type="text" name="" id="editar_categoria">
        <br>
        Autor:
        <br>
        <input type="text" name="" id="editar_autor">
        <br>
        Idioma:
        <br>
        <input type="text" name="" id="editar_idioma">
        <br>
        Editorial:
        <br>
        <input type="text" name="" id="editar_editorial">
        <br>
        Año de publicación:
        <br>
        <input type="text" name="" id="editar_anioPublicacion">
        <br>
        Archivo descarga:
        <br>
        <input type="text" name="" id="editar_descarga">
        <br>
        Archivo previsualizacion:
        <br>
        <input type="text" name="" id="editar_previsualizacion">
        <br>
        Monto:
        <br>
        <input type="number" name="" id="editar_monto">
        <br>
        <button type="button" onclick="guardar_cambios()">Guardar cambios</button>
        <button>Cancelar</button>
    </div>

    <div id="contenedor_crear">
        Nombre:
        <br>
        <input type="text" name="" id="crear_nombre">
        <br>
        Categoria:
        <br>
        <input type="text" name="" id="crear_categoria">
        <br>
        Autor:
        <br>
        <input type="text" name="" id="crear_autor">
        <br>
        Idioma:
        <br>
        <input type="text" name="" id="crear_idioma">
        <br>
        Editorial:
        <br>
        <input type="text" name="" id="crear_editorial">
        <br>
        Año de publicación:
        <br>
        <input type="text" name="" id="crear_anioPublicacion">
        <br>
        Archivo descarga:
        <br>
        <input type="text" name="" id="crear_descarga">
        <br>
        Archivo previsualizacion:
        <br>
        <input type="text" name="" id="crear_previsualizacion">
        <br>
        Monto:
        <br>
        <input type="number" name="" id="crear_monto">
        <br>
        <button type="button" onclick="crear_elemento()">Crear nuevo libro</button>
        <button>Cancelar</button>
    </div>

    <script>
        cargar_elementos();
        contenedorTabla_visible("inline");
        contenedorEditar_visible("none");
        contenedorCrear_visible("none");
    </script>
</asp:Content>
