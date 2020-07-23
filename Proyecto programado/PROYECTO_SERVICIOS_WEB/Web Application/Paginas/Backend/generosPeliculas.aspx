<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Backend.Master" AutoEventWireup="true" CodeBehind="categoriasGenerosPelMusLib.aspx.cs" Inherits="Web_Application.Paginas.Backend.categoriasGenerosPelMusLib" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Public/scripts/generosPeliculas.js"></script>
    <link rel="stylesheet" href="../../Public/estilos/generosCategoriasProductos.css">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="./index.aspx">Inicio</a></li>
            <li class="breadcrumb-item active" aria-current="page">Administracion de generos y categorias.</li>
        </ol>
    </nav>
    <div class="titulo">
        Administracion de generos de peliculas
    </div>

    <div class="descripcion">
        Utilice los controles para administrar
    </div>

    <div class="contenedor">
        <div class="formulario">
            <h3>Ingresar genero nuevo</h3>
            <input type="text" name="ingresar_categoria_contenido" id="input_elementoNuevo">
            <br>
            <button type="button" onclick="ingresar_elemento()">Guardar</button>
        </div>

        <div class="formulario">
            <h3>Editar genero</h3>
            <label for="">ID</label>
            <br>
            <input type="text" name="actualizar_categoria_id" id="inputId_elementoActualizar">
            <br>
            <label for="">Nuevo genero</label>
            <br>
            <input type="text" name="actualizar_genero_contenido" id="inputContenido_elementoActualizar">
            <br>
            <button type="button" onclick="actualizar_elemento()">Actualizar</button>
        </div>

        <div class="formulario">
            <h3>Eliminar genero</h3>
            <label for="">ID</label>
            <br>
            <input type="text" name="eliminar_datos" id="inputId_elementoEliminar">
            <br>
            <button type="button" onclick="eliminar_elemento()">Eliminar</button>
        </div>
    </div>

    <div class="formulario">
        <div id="http_response_contenido">
            <div class="spinner-border text-primary" role="status">
                <span class="sr-only">Loading...</span>
            </div>
            Cargando...
        </div>
    </div>

    <script>
        obtener_elementos();
    </script>

</asp:Content>