<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Backend.Master" AutoEventWireup="true" CodeBehind="categoriasGenerosPelMusLib.aspx.cs" Inherits="Web_Application.Paginas.Backend.categoriasGenerosPelMusLib" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Public/scripts/categoriasGenerosPelMusLib.js"></script>
    <link rel="stylesheet" href="../../Public/estilos/categoriasGenerosPelMusLib.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="./index.aspx">Inicio</a></li>
            <li class="breadcrumb-item active" aria-current="page">Administracion de generos y categorias.</li>
        </ol>
    </nav>
    <div class="titulo">
        Administracion de generos y categorias de productos
    </div>

    <div class="descripcion">
        Seleccione el elemento que desea administrar.
    </div>

    <div class="contenedor">
        <div class="formulario">
            <h3>Ingresar genero nuevo</h3>
            <input type="text" name="ingresar_categoria_contenido" id="ingresarGenero_pelicula__input">
            <br>
            <button onclick="ingrearGenero_pelicula()">Guardar genero</button>
        </div>

        <div class="formulario">
            <h3>Editar genero</h3>
            <label for="">ID del genero</label>
            <br>
            <input type="text" name="actualizar_categoria_id" id="actualizarGenero_pelicula_id_input">
            <br>
            <label for="">Nuevo genero</label>
            <br>
            <input type="text" name="actualizar_genero_contenido" id="actualizarGenero_pelicula_contenido_input">
            <br>
            <button onclick="actualizar_datos()">Actualizar genero</button>
        </div>

        <div class="formulario">
            <h3>Eliminar genero</h3>
            <label for="">ID del genero</label>
            <br>
            <input type="text" name="eliminar_datos" id="eliminarGenero_pelicula_id_input">
            <br>
            <button onclick="eliminar_datos()">Eliminar genero</button>
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
    </div>

    <script>
    alert("asdsd")
        cargar_generosPeliculas();
    </script>
    
</asp:Content>